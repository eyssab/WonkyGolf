using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public KeyCode shootKey;
    public Transform target;
    public Transform objecti;
    public Transform lastPos;
    public bool pressing;
    public float timeRemaining = 10f;
    public int power = 10;
    public int putts = 0;
    public bool carrying = false; 

    public Powerbar powerBar;
    public string name1;

    void Start()
    {
        name1 = "Player";
    }

    void Update()
    {
        if (pressing && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (Input.GetKey(shootKey))
            {
                FindObjectOfType<AudioManager>().Play("BallHit");
                objecti.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = objecti.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * power;
                objecti.transform.parent = null;
                GameObject.Find("ball1").GetComponent<Rigidbody>().isKinematic = false;
                objecti.transform.position = objecti.transform.position;
            }
            else{
                if (Input.GetMouseButtonUp(0) | timeRemaining <= 0f)
                {
                    putts++;
                    timeRemaining = 0f;
                    GameObject.Find("Player").GetComponent<Movement>().speed = 8f;
                    carrying = false;
                }
            }
            
            //setting power using scroll wheel
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f && power < 60)
            {
                power += 3;
                powerBar.SetPower(power);
            }
            else if (d < 0f && power > 1)
            {
                power -= 3;
                powerBar.SetPower(power);
            }
        }
        else
        {
            pressing = false;
            timeRemaining = 10f;
            objecti.transform.parent = null;
            GameObject.Find("ball1").GetComponent<Rigidbody>().isKinematic = false;
            power = 10;
        }

    }
    //slowing down the ball
    void FixedUpdate()
    {
        Rigidbody rb = objecti.GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.05f;
        rb.velocity = rb.velocity / 1.005f;
        //out of bounds test
        if (rb.velocity.magnitude <= 0.5f)
        {
            lastPos.transform.position = objecti.transform.position;
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.transform.GetComponent<Rigidbody>();
        if (col.transform.tag == "Holdable")
        {
            objecti.transform.SetParent(target.transform);
            objecti.localPosition = new Vector3(0, 0, 0);
            rb.isKinematic = true;
            pressing = true;
            GameObject.Find("Player").GetComponent<Movement>().speed = 0f;
            carrying = true;
        }
    }
}