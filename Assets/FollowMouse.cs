using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //map the mouse to a world position
        Vector3 mousePos = Input.mousePosition;

        //reflect this point
        mousePos.y = Screen.height - mousePos.y;
        mousePos.x = Screen.width - mousePos.x;

        mousePos.z = 10;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Now we want to rotate in 3D space so we are looking at this worldPos
        transform.LookAt(worldPos,transform.up);

        
        





    }
}
