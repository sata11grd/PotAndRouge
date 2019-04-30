using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour{
    GameObject active,disactive;
    int flag=0;
    public int val;
    bool isActive=false;
    float X=0,Y=0;
    Vector3 start;
    public void Start(){
        start=transform.position;
        active = transform.GetChild(0).gameObject;
        disactive = transform.GetChild(1).gameObject;
        Off();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            flag++;
            flag=Mathf.Clamp(flag,0,2);
            if(flag==val)On();
            else Off();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            flag--;
            flag=Mathf.Clamp(flag,0,2);
            if(flag==val)On();
            else Off();
        }
        if(Input.GetKeyDown(KeyCode.Return)&&isActive){
            Action();
        }
    }
    void FixedUpdate(){
        if(isActive){
            //transform.Rotate(new Vector3(0,0,Random.Range(-10.0f,10.0f)));
            X=-(Mathf.Log(1-Random.Range(0,1f))*10f-5f);
            Y=Mathf.Log(1-Random.Range(0,1f))*10f-5f;
            transform.position=new Vector3(start.x+X,start.y+Y,0);
        }
    }
    public virtual void Action(){

    }
    public void Quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
        #endif
    }
    public void On(){
        isActive=true;
        active.SetActive(true);
        disactive.SetActive(false);
    }
    public void Off(){
        isActive=false;
        active.SetActive(false);
        disactive.SetActive(true);
    }
}
