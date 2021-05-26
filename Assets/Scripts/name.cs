using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class name : MonoBehaviour
{
    public string name1;
    public Text name1t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        name1 = GameObject.Find("Arm").GetComponent<Grab>().name1;
        name1t.text = name1;
    }
}
