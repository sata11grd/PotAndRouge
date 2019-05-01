using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wlupdown : MonoBehaviour
{
    public float hightWl;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector2(0.0f, hightWl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
