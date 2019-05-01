using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public float rightscore = 0;
    public float leftscore = 0;
    public float sumscore;
    public float winscore;
    public float gametime = 0;
    public GameObject LWC;
    private Lwc lwc;
    private float g;
    public GameObject right;
    public GameObject left;
    private Scorepad rs;
    private Scorepad ls;
    public GameObject Daizawin;
    // Start is called before the first frame update
    void Start()
    {
        lwc = LWC.GetComponent<Lwc>();
        rs = right.GetComponent<Scorepad>();
        ls = left.GetComponent<Scorepad>();
        rs.powerON = true;
        ls.powerON = true;
        if (rightscore > leftscore)
        {
            winscore = rightscore;
        }
        else
        {
            winscore = leftscore;
            lwc.change = true;
            GetComponent<CharaChange>().charachange = true;
        }
        sumscore = rightscore + leftscore;
        lwc.powerON = true;
        GetComponent<CharaChange>().powerON = true;
        Daizawin.GetComponent<DWupdown>().powerON = true;
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
