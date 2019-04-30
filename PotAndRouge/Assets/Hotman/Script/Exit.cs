using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Button{
    void Start(){
        val=2;
        base.Start();
    }
    override public void Action(){
        base.Quit();
    }
}