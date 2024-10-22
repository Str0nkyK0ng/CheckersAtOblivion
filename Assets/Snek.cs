using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Snek will move on the grid
public class Snek : MonoBehaviour
{

    public Grid grid;
    public int x,y;
    // Start is called before the first frame update
    void Start()
    {
        x=0;
        y=0;
        grid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    public float timer=0;
    public float inputX=0;
    public float inputY=0;
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>0.5f){
            timer=0;
            Move();
        }

        if(Input.GetAxis("Horizontal")!=0){
            inputX= (int)(1 * (Input.GetAxis("Horizontal")/Mathf.Abs(Input.GetAxis("Horizontal"))));
            inputY=0;
        }

        if(Input.GetAxis("Vertical")!=0){
            inputY= (int)(1 * (Input.GetAxis("Vertical")/Mathf.Abs(Input.GetAxis("Vertical"))));
            inputX=0;
        }

      
    }

    public void Move(){
        // Move in the right dir
        x+=Mathf.RoundToInt(inputX);
        y+=Mathf.RoundToInt(inputY);

        // Check if we are out of bounds
        if(x>=grid.width || x<0){
            x=0;
        }
        if(y>=grid.height || y<0){
            y=0;
        }
        // Move the snek
        transform.position = new Vector3(grid.grid[x][y].x*2,grid.grid[x][y].y*2,-5);
    }


}
