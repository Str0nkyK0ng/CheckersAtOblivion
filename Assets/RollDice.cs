using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 5;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // tell the physics raycaster to ignore the DICE layer when clicking on the screen
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            RollPhysicsDice();
            onGround=false;
        }
        ChangeSound();
    }

    public void RollPhysicsDice(){
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
