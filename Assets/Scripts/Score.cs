using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int putts;
    public Text puttText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        putts = GameObject.Find("Arm").GetComponent<Grab>().putts;
        puttText.text = putts.ToString();
    }
}
