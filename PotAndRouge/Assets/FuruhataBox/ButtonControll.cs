using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    public bool powerON1 = false;
    public bool powerON2 = false;
    
    public float smallsize = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerON1)
        {
            transform.localScale *= smallsize;
            
            powerON1 = false;
        }
        if (powerON2)
        {
            transform.localScale /= smallsize;

            powerON2 = false;
        }
    }
}
