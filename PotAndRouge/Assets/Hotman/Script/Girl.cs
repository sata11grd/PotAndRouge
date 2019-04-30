using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour{
    float X=0,Y=0;
    float InitialY { get; set; }
    void Start(){
        InitialY = transform.position.y;
    }
    void FixedUpdate(){
        Y=-20*Mathf.Pow(Mathf.Sin(2*Time.frameCount*Mathf.PI/180),2);
        transform.position=new Vector3(transform.position.x,Y+InitialY,0);
    }
}
