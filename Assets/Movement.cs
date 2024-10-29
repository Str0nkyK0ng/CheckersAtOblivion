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

    public Vector2 smooth2DNoise(float x, float y)
    {
        float s = Mathf.PerlinNoise(x, y);
        float t = Mathf.PerlinNoise(y, x);
        return new Vector2(s, t);
    }

    Vector3 move;
    // Update is called once per frame
    void Update()
    {
        Vector2 noise = smooth2DNoise(Time.time, Time.time);
        // float horiz = Input.GetAxis("Horizontal");
        float horiz = noise.x;

        // float vert = Input.GetAxis("Vertical");
        float vert = noise.y;
        //  move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        move = transform.right * horiz + transform.forward * vert;
        if(Input.GetKeyDown(KeyCode.Space)){
            move.y = Mathf.Sqrt(2*Mathf.Abs(Physics.gravity.y)*jumpHeight);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(this.transform.position + move *Time.fixedDeltaTime);

    }
}
