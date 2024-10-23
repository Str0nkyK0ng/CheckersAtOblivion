using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradeMarquee : MonoBehaviour
{
    public RectTransform rectTransform;
    public float speed=100f;
    public float degradeFactor=1.005f;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    void Start(){
        DegradeManager.instance.onDegrade.AddListener(Degrade);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 anchor = rectTransform.anchoredPosition;
        anchor.x -= speed*Time.deltaTime;
        if(anchor.x < - 15650){
            anchor.x = 1920;
        }
        rectTransform.anchoredPosition = anchor;
    }

    void Degrade(){
        speed *= Mathf.Pow(degradeFactor,DegradeReality.degration);
    }
}
