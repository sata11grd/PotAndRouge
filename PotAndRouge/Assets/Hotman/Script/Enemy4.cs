using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Character{
    void Start(){
        SetPosition(1920/2,1180);
    }
    void Update(){
        AddPosition(0,Random.Range(5,-10));
        if(IsOutside2())DestroyObj();
    }
}
