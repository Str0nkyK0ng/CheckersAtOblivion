using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public GameObject[] targets;
    public GameObject currentTarget;
    public float swapTimer=5;
    private float timer=0;
    public float speed=1;

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>swapTimer){
            timer=0;
            GameObject target = null;
            while(target ==null || target.activeInHierarchy==false){
                int index = Random.Range(0,targets.Length);
                target = targets[index];
            }
            currentTarget = target;
        }

        Vector3 newDir = Vector3.RotateTowards(transform.forward, currentTarget.transform.position-transform.position,speed*Time.deltaTime,0.0f);
        // add a little bit of noise
        newDir += Random.onUnitSphere*0.01f;
        
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
