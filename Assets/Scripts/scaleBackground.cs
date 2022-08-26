using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempscale = transform.localScale;
        float heiht = sr.bounds.size.y;
        float widht = sr.bounds.size.x;
        float backGroundHeiht = Camera.main.orthographicSize * 2f;
        float backGroundWidht = backGroundHeiht * Screen.width / Screen.height;
        tempscale.y = backGroundHeiht / heiht;
        tempscale.x = backGroundWidht / widht;
        transform.localScale = tempscale;
    }
}
