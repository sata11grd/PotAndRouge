using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaChange : MonoBehaviour
{
    public float DaiHight = 0;
    public GameObject rightchan;
    public GameObject leftchan;
    public GameObject Dw;
    public GameObject Dl;
    public bool powerON = false;
    public bool charachange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerON)
        {
            Vector3 o = new Vector3(0, DaiHight, 0);
            if (charachange)
            {
                rightchan.transform.parent = Dl.transform;
                leftchan.transform.parent = Dw.transform;
            }
            else
            {
                rightchan.transform.parent = Dw.transform;
                leftchan.transform.parent = Dl.transform;
            }
            rightchan.transform.localPosition = o;
            leftchan.transform.localPosition = o;
            powerON = false;
        }
    }
}
