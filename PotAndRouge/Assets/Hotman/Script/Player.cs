using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character{
    bool moveUp=true;
    float sizeY;
    [SerializeField]
    public float minY,maxY;
    public Transform center;
    Vector2 min,max;
    void Start(){
        SetPosition(1920/2,1080/2);
    }
    void Update(){
        if(Input.GetKey(KeyCode.UpArrow)){
            AddPosition(0,10);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            AddPosition(0,-10);
        }
        SetPosition(screenX(),Mathf.Clamp(screenY(),minY,maxY));
    }
}
