using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradeTable : MonoBehaviour
{
    DegradeTile[] tableSpots;
    public float timeToIncrease=1;
    public float degradeFactor=1.005f;
    public float inc=0;
    private float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        tableSpots = this.transform.GetComponentsInChildren<DegradeTile>();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>timeToIncrease){
            timer=0;
            Degrade();
        }
    }

    void Degrade(){
        inc++;
        float variation = Mathf.Pow(degradeFactor,inc)-1;
        foreach(DegradeTile spot in tableSpots){
            spot.desiredPosition =  spot.transform.localPosition + new Vector3(Random.Range(-variation,variation),0,Random.Range(-variation,variation));
        }

    }
}
