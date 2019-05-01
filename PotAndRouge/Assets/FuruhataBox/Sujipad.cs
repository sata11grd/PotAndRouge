using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sujipad : MonoBehaviour
{
    public bool set = false;
    public int kurai0 = 0;
    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public int waitframe10 = 0;
    private int waitframe;
    private int sn = 0;
    private Image sr;
    public int tw = 1;
    private int k = 0;
    Sprite[] sprites = new Sprite[10];
    // Start is called before the first frame update
    void Start()
    {
        sprites[0] = s0;
        sprites[1] = s1;
        sprites[2] = s2;
        sprites[3] = s3;
        sprites[4] = s4;
        sprites[5] = s5;
        sprites[6] = s6;
        sprites[7] = s7;
        sprites[8] = s8;
        sprites[9] = s9;
        sr = GetComponent<Image>();
        waitframe = waitframe10 * 10+1+kurai0;
    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            if (waitframe > 0)
            {
                if (k % tw == 0)
                {
                    --waitframe;
                    sr.sprite = sprites[sn];
                    if (sn < 9) { ++sn; } else { sn = 0; }
                }
                ++k;
            }
            else
            {
                set = false;
            }
        }
    }
}
