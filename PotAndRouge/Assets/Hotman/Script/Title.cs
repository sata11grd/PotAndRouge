using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour{
    float X=0,Y=0;
    void Start(){
        
    }
    void Update(){
        X+=Random.Range(-5f,5f);
        Y+=Random.Range(-5f,5f);
        X=Mathf.Clamp(X,-20,20);
        Y=Mathf.Clamp(Y,-20,20);
        transform.position=new Vector3(X+960,Y+540,0);
    }
}
