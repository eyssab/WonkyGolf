using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carryTimer : MonoBehaviour
{
    public float timeRemaining = 10f;
    public Text timer;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Arm").GetComponent<Grab>().carrying == true) {
            timeRemaining -= Time.deltaTime;
            timer.text = Mathf.Floor(timeRemaining).ToString();
        }
        else
        {
            timeRemaining = 10f;
            timer.text = Mathf.Floor(timeRemaining).ToString();
        }
        if (timeRemaining <= 0f)
        {
            timeRemaining = 10f;
            timer.text = Mathf.Floor(timeRemaining).ToString();
        }
    }
}