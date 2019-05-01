using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public GameObject homeButton;
    public GameObject restartButton;
    public KeyCode up;
    public KeyCode down;
    public KeyCode gosign;
    private int c = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up) || Input.GetKeyDown(down)) { c *= -1;powerON(); }
        if (Input.GetKeyDown(gosign))
        {
            if (c == 1) { HomeGo(); } else { RestartGo(); }
        }
        
    }
    //ホームに戻る
    void HomeGo()
    {

    }
    //リスタートする
    void RestartGo()
    {

    }
    void powerON()
    {
        if (c == 1)
        {
            homeButton.GetComponent<ButtonControll>().powerON1 = true;  restartButton.GetComponent<ButtonControll>().powerON2 = true; 
        }
        else
        {
            homeButton.GetComponent<ButtonControll>().powerON2 = true; restartButton.GetComponent<ButtonControll>().powerON1 = true;
        }
    }
}
