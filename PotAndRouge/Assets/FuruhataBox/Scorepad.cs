using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WinSpad))]

public class Scorepad : MonoBehaviour
{
    public GameObject canvas;
    public GameObject W;
    public GameObject L;
    private WinSpad winspad;
    private WinSpad losespad;
    private Data data;
    public bool win;
    private float score0;
    private int score;
    private int keta=1;
    public bool powerON = false;
    private int h;
    public int[] kurai;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (powerON)
        {
            winspad = W.GetComponent<WinSpad>();
            losespad = L.GetComponent<WinSpad>();
            data = canvas.GetComponent<Data>();
            if (win)
            {
                score0 = data.rightscore;
            }
            else
            {
                score0 = data.leftscore;
            }
            //int変換
            string g = score0.ToString();
            score = int.Parse(g);
            //桁数の決定
            for (int i = 10; score >= i; i *= 10)
            {
                ++keta;
            }
            //位の値の調査
            kurai = new int[keta];
            h = score;
            for (int i = 1; i <= keta; ++i)
            {
                kurai[i - 1] = h % 10;
                h = (h - kurai[i - 1]) / 10;
            }
            if (win)
            {
                winspad.ketas = keta;
                winspad.kura = kurai;
                winspad.seisei = true;
            }
            else
            {
                losespad.ketas = keta;
                losespad.kura = kurai;
                losespad.seisei = true;
            }
            powerON = false;
        }
    }
}
