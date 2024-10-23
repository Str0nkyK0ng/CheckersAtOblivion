using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MouseLook : MonoBehaviour
{


    public Transform playerBody;
    public bool lookingEnabled = true;

    float xRotation = 0f;
    public float mouseSens = 100f;
    public float maxAngle = 45f;
    public float minAngle = -45f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("mouseSens", mouseSens);
    }

    // Update is called once per frame
    void Update()
    {
        if (!lookingEnabled)
            return;
        float mouseX = Input.GetAxis("Mouse X") * PlayerPrefs.GetFloat("mouseSens", 10f) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("mouseSens", 10f) * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);


        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


    }


}
