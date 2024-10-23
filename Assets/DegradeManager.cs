using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DegradeManager : MonoBehaviour
{
    public static DegradeManager instance;
    public float timer=0;
    public float time=5;
    public UnityEvent onDegrade;
    public void Awake(){
        instance=this;
        onDegrade=new UnityEvent();
    }
    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>time){
            timer=0;
            onDegrade.Invoke();
            DegradeReality.Increase();
        }
    }
}
