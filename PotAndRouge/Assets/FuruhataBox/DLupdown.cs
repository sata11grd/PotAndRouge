using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLupdown : MonoBehaviour
{
    public float Ldown;
    public float Lspeed;
    private float b;
    // Start is called before the first frame update
    void Start()
    {
        b = Ldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (b > 0)
        {
            b -= Lspeed;
            transform.Translate(0.0f,-Lspeed, 0.0f);
        }
    }
}
