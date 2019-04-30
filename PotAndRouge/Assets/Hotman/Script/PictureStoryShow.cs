using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureStoryShow : MonoBehaviour{
    GameObject[] obj = new GameObject[10];
    public int nowDisp=0;
    void Start(){
        for(int i=0;i<10;i++){
            obj[i] = transform.GetChild(i).gameObject;
            if(i!=0)obj[i].SetActive(false);
        }
    }
    void FixedUpdate(){
        if(Time.frameCount%100==99){
            if(nowDisp==9){
                //SceneManager.LoadScene("Load");
                SceneManager.UnloadSceneAsync("Prologue");
            }else{
                obj[nowDisp].SetActive(false);
                nowDisp++;
                obj[nowDisp].SetActive(true);
            }
        }
    }
}
