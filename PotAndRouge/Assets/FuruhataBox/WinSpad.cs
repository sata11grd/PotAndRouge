using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSpad : MonoBehaviour
{
    public int ketas = 1;
    public float x;
    public float y;
    public float interval;
    public GameObject suji;
    public int[] kura;
    public bool seisei = false;
    private Sujipad[] sujipads;
    private GameObject[] gameObjects;
    private int i;
    private bool p = true;
    private  Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (seisei)
        {
            if (p)
            {
                gameObjects = new GameObject[ketas];
                sujipads = new Sujipad[ketas];
                i = ketas ;
                p = false;
            }
            else
            {
                if (i > 0)
                {
                    --i;
                    gameObjects[i] = Instantiate(suji, transform);
                    sujipads[i] = gameObjects[i].GetComponent<Sujipad>();
                    gameObjects[i].transform.SetPositionAndRotation(Camera.main.ScreenToWorldPoint(Camera.main.transform.position +pos+ new Vector3(i * interval, 0, 0), Camera.MonoOrStereoscopicEye.Mono), Quaternion.identity);
                    sujipads[i].kurai0 = kura[i];
                    sujipads[i].set = true;
                }
                else
                {
                    seisei = false;
                }
            }
           
            
        }
    }
}
