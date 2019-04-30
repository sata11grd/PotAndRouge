using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy2 : Character{
    float startX,startY;
    void Start(){
        SetPosition(1920/2,1180);
        startX=screenX();
        startY=screenY();
    }
    void Update(){
       SetPosition(startX+100*(float)Math.Sin(Time.frameCount*10*Math.PI/180),screenY()-5);
       if(IsOutside2())DestroyObj();
    }
}
