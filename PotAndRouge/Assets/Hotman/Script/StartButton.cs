using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : Button{
    void Start(){
        val=0;
        base.Start();
        On();
    }
    override public void Action(){
        SceneManager.LoadScene("Prologue");
        SceneManager.UnloadSceneAsync("Title");
        //Scene scene = SceneManager.GetSceneByName("Prologue");
        //SceneManager.SetActiveScene(scene);
    }
}