using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradeTile : MonoBehaviour
{
    public Vector3 desiredPosition;
    public float speed=1f;
    public float degradeFactor=1.005f;

    void Start(){
        desiredPosition = transform.localPosition;
        DegradeManager.instance.onDegrade.AddListener(Degrade);
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition,desiredPosition,Time.deltaTime*speed);
    }

    void Degrade(){
        float variation = Mathf.Pow(degradeFactor,DegradeReality.degration)-1;
        desiredPosition =  transform.localPosition + new Vector3(Random.Range(-variation,variation),0,Random.Range(-variation,variation));
    }
}
