using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{

    public float gravity=-10;
    public float jumpStrength=5;
    public float velocity=0;
    public float maxPos=2;
    public float maxVel=1;
    public float minY=-10;
    public float maxY=10;


    public float xRange=3;
    public float xSpeed=1;

    public void Start(){
        DegradeManager.instance.onDegrade.AddListener(()=>{xSpeed++;});
    }

    public void Update(){
        velocity+=gravity*Time.deltaTime;

        if(Input.GetMouseButtonDown(0)){
            velocity+=jumpStrength;
            SFXManager.instance.PlaySFX("jump",true);
        }

        velocity = Mathf.Clamp(velocity,-maxVel,maxVel);

        Vector3 position = this.transform.localPosition;
        position.y += velocity*Time.deltaTime;
        position.y = Mathf.Clamp(position.y,-maxPos,maxPos);

        //do x stuff
        position.x += Time.deltaTime*xSpeed;
        if(position.x>xRange){
            position.x = - xRange;
            // give them a random rotation
            transform.localRotation = Quaternion.Euler(Random.Range(-45,45),Random.Range(-45,45),Random.Range(-45,45));
        }
        else if (position.x < - xRange){
            position.x = xRange;
            transform.localRotation = Quaternion.Euler(Random.Range(-45,45),Random.Range(-45,45),Random.Range(-45,45));
        }

        this.transform.localPosition = position;

    }
}
