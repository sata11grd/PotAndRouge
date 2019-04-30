using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{
    public float X {
        set {
            Vector3 pos = transform.position;
            pos.x = value;
            transform.position = pos;
        }
        get { return transform.position.x; }
    }
    /// 座標(Y).
    public float Y {
        set {
            Vector3 pos = transform.position;
            pos.y = value;
            transform.position = pos;
        }
        get { return transform.position.y; }
    }
        /// 座標を足し込む.
    public void AddPosition (float dx, float dy){
        SetPosition(screenX()+dx,screenY()+dy);
    }
    /// 座標を設定する.
    public void SetPosition (float x, float y){
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(x,y,Camera.main.transform.position.z));
        pos.z=0;
        transform.position = pos;
    }
    public float ScaleX {
        set {
            Vector3 scale = transform.localScale;
            scale.x = value;
            transform.localScale = scale;
        }
        get { return transform.localScale.x; }
    }

    /// スケール値(Y).
    public float ScaleY {
        set {
            Vector3 scale = transform.localScale;
            scale.y = value;
            transform.localScale = scale;
        }
        get { return transform.localScale.y; }
    }
    public float screenX(){
        return RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position).x;
    }
    public float screenY(){
        return RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position).y;
    }
    public bool IsOutside (){
        Vector3 min = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.z));
        Vector3 max = Camera.main.ScreenToWorldPoint(new Vector3(1920,1080,Camera.main.transform.position.z));
        Vector2 pos = transform.position;
        if (pos.x < min.x || pos.y < min.y) {
            return true;
        }
        if (pos.x > max.x || pos.y > max.y) {
            return true;
        }
        return false;
    }
    public bool IsOutside2 (){
        Vector3 min = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.z));
        Vector3 max = Camera.main.ScreenToWorldPoint(new Vector3(1920,1080,Camera.main.transform.position.z));
        Vector2 pos = transform.position;
        if (pos.x < min.x || pos.y < min.y || pos.x > max.x) {
            return true;
        }
        return false;
    }
    public void DestroyObj (){
        Destroy (gameObject);
    }

}
