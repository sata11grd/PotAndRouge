using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lwc : MonoBehaviour
{
    public bool change = false;
    public GameObject Wintext;
    public GameObject Losetext;
    public bool powerON = false;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (powerON)
        {
            if (change)
            {
                transform.Rotate(0.0f, 180f, 0.0f);
                Wintext.transform.Rotate(0.0f, 180f, 0.0f);
                Losetext.transform.Rotate(0.0f, 180f, 0.0f);
            }
            powerON = false;
        }
    }
}
