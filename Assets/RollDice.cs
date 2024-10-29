using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 5;
    public AudioSource source;

    public float timeOnGround=3;
    public float timer=0;

    public float panicTimer=0;
    private float panicTime=5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //DegradeManager.instance.onDegrade.AddListener(RollPhysicsDice);
        // tell the physics raycaster to ignore the DICE layer when clicking on the screen
        DegradeManager.instance.onDegrade.AddListener(()=>{panicTime= 5-Mathf.Log(DegradeReality.degration);});
        DegradeManager.instance.onDegrade.AddListener(()=>{timeOnGround= 5-Mathf.Log(DegradeReality.degration);});


    }

    // Update is called once per frame
    void Update()
    {

        if(onGround){
            timer+=Time.deltaTime;
        }
        else{
            timer=0;
        }
        if(timer>timeOnGround){
            timer=0;
            RollPhysicsDice();
        }

        if(!onGround){
            panicTimer+=Time.deltaTime;
            if(panicTimer>panicTime){
                panicTimer=0;
                RollPhysicsDice();
            }
        }
        ChangeSound();
    }

    public void RollPhysicsDice(){
        onGround=false;
        rb.AddForce(Vector3.up*force,ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere*force,ForceMode.Impulse);
    }

    public bool onGround=true;

    public void OnCollisionEnter(Collision col){
        if(col.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast")){
            onGround=true;
        }
    }

    public void OnCollisionExit(Collision col){
        if(col.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast")){
            onGround=false;
        }
    }

    public void ChangeSound(){
        if(!onGround){
            source.volume = 0;
            return;
        }
        //change the volume of our sound based off the drag on our rb
        source.volume = rb.velocity.magnitude/10;
    }
}
