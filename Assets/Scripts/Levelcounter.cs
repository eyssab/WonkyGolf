using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelcounter : MonoBehaviour
{
    public int level;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level = GameObject.Find("ball1").GetComponent<Hole>().score;
        levelText.text = level.ToString();
    }
}