using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Character{
    void Start(){
        SetPosition(1920/2,1180);
    }
    void Update(){
        AddPosition(Random.Range(-10,10),-5);
        if(IsOutside2())DestroyObj();
    }
}