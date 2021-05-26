using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoremenu : MonoBehaviour
{
    public GameObject ScorepanelUI;

    // Start is called before the first frame update

    void Start()
    {
        GameObject Scorepanel = GameObject.Find("Scorepanel");
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Loadscore();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Hidescore();
        }
    }
    public void Loadscore()
    {
        ScorepanelUI.SetActive(true);
    }
    public void Hidescore()
    {
        ScorepanelUI.SetActive(false);
    }
}
