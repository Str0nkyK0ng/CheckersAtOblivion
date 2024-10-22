using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public List<List<Vector2>> grid;
    public int width=8;
    public int height=8;

    float degradeFactor=1.05f;
    // Start is called before the first frame update
    void Start()
    {

        Board newBOard = new Board();
        print(newBOard.Visualize());

        grid = new List<List<Vector2>>();

        // Generate a standard 2d array
        for(int x=0;x<width;x++){
            grid.Add(new List<Vector2>());
            for(int y=0;y<height;y++){
                grid[x].Add( new Vector2(x,y));
            }
        }

        // Ltets print it
        string s="";
        for(int x=0;x<width;x++){
            s+="\n";
            for(int y=0;y<height;y++){
                s+="["+x+","+y+"]";
            }
        }
        Degrade();
        Visualize();
    }

    void Visualize(){
        for(int x=0;x<width;x++){   
            for(int y=0;y<height;y++){
                // Create a cube
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // change the color, in a checkerboard pattern

                bool baseColor = (x%2==0 && y%2==0) || (x%2!=0 && y%2!=0);
                if(baseColor){
                    cube.GetComponent<Renderer>().material.color = new Color(1,0,0,0.5f);
                }else{
                    cube.GetComponent<Renderer>().material.color = new Color(0,1,0,0.5f);
                }
                float scaleSize = 2;

                cube.transform.position = new Vector3(scaleSize*grid[x][y].x,scaleSize*grid[x][y].y,0);
                // scale it 
                cube.transform.localScale = Vector3.one*scaleSize;
            }
        }
    }


    void Degrade(){
        for(int x=0;x<width;x++){
            for(int y=0;y<height;y++){
                // Depending on the HEIGHT, move the piece a bit
                float degradeValue = Mathf.Pow(degradeFactor,y)-1;
                float variationX = Random.Range(-1f,1f)*degradeValue;
                float variationY = Random.Range(-1f,1f)*degradeValue;

                grid[x][y]+= new Vector2(variationX,variationY);
            }
        }
    }
}
