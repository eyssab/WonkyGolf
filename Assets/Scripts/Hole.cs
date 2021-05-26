using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    public int score = 0;
    public GameObject player;
    public Transform ball1;
    public Transform tpManager;
    public Transform lastPos;
    private int score1 = 0;

    public void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.transform.GetComponent<Rigidbody>();
        if (col.transform.tag == "hole")
        {
            score++;
            Debug.Log(score);
            FindObjectOfType<AudioManager>().Play("Hole!");
            if(score1 < score)
            {
                Transform tpPos = tpManager.transform.GetChild(score-1);
                Transform ballpos = tpPos.transform.GetChild(0);
                player.transform.position = tpPos.transform.position;
                ball1.transform.position = ballpos.transform.position;
                GameObject.Find("ball1").GetComponent<Rigidbody>().isKinematic = true;
                GameObject.Find("ball1").GetComponent<Rigidbody>().isKinematic = false;
                score1++;
            }
        }

        if(col.transform.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(col.transform.tag == "OutOfBounds")
        {
            GameObject.Find("ball1").GetComponent<Rigidbody>().isKinematic = true;
            ball1.transform.position = lastPos.transform.position;
        }
    }
}
