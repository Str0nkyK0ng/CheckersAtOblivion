using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradeTile : MonoBehaviour
{
    public Vector3 desiredPosition;
    public float speed=1f;

    void Start(){
        desiredPosition = transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition,desiredPosition,Time.deltaTime*speed);
    }
}
