using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy3 : Character{
    void Start(){
        SetPosition(1920/2,1180);
    }
    void Update(){
        AddPosition(0,-5);
        ScaleX=(float)Math.Pow(Math.Sin(Time.frameCount*10*Math.PI/180),2);
        ScaleY=(float)Math.Pow(Math.Sin(Time.frameCount*10*Math.PI/180),2);
        if(IsOutside2())DestroyObj();
    }
}
