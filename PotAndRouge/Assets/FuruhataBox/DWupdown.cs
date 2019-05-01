using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWupdown : MonoBehaviour
{
    private float score;
    public float maxhight;
    public float scorespeed;
    private float a = 0;
    public GameObject winscore;
    public GameObject scoredata;
    public GameObject LWc;
    private Data data;
    public float wsnear;
    public float wsnspeed;
    public bool powerON = false;
    private float scoresum;
    //private float j;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (a > 0)
        {
            a -= scorespeed;
            transform.Translate(0.0f, scorespeed, 0.0f);
        }
        if (powerON)
        {
            data = scoredata.GetComponent<Data>();
            score = data.winscore;
            scoresum = data.sumscore;
            a = maxhight * score / scoresum;
            powerON = false;
        }
    }
    
}
