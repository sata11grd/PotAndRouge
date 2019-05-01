using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : Button{
    [SerializeField] UnityEngine.Events.UnityEvent OnPressed;

    void Start(){
        val=1;
        base.Start();
    }
    override public void Action(){
        OnPressed.Invoke();
    }
}