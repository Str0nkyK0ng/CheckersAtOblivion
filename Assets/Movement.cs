using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public bool canMove = true;
    public Rigidbody rb;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    Vector3 move;
    // Update is called once per frame
    void Update()
    {
         move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space)){
            move.y = Mathf.Sqrt(2*Mathf.Abs(Physics.gravity.y)*jumpHeight);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(this.transform.position + move *Time.fixedDeltaTime);

    }
}
