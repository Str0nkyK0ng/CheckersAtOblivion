using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecraft : MonoBehaviour
{
    Mesh planeMesh;


    // Start is called before the first frame update
    void Awake(){
        planeMesh = new Mesh();
        planeMesh.vertices = new Vector3[]{
            new Vector3(0.5f,0.5f,-0.5f),
            new Vector3(0.5f,0.5f,0.5f),
            new Vector3(-0.5f,0.5f,0.5f),
            new Vector3(-0.5f,0.5f,-0.5f),
        };
        planeMesh.triangles = new int[] {0,1,2,2,3,0};
    }
    void Start()
    {
        GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int width=75;
    public int height=75;
    public void GenerateWorld(){
        //lets create a 100x100 gradient noise texture
        for(int x=0;x<width;x++){
            for(int y=0;y<height;y++){
                //Lets combine two noises, perlin and simplex
                float value;
                //three octaves of noise
                value = Mathf.PerlinNoise(x/10f,y/10f);
                value += Mathf.PerlinNoise(x/5f,y/5f);
                value += Mathf.PerlinNoise(x/2f,y/2f);
                value /= 3;
                value*=10;

                value = Mathf.RoundToInt(value);

                CreateBlock(x,y,value);
            }
        }
    }


    public void CreateBlock(float localX, float localY, float localZ){
        //Create a primitve at that location (x,y,value*10)
        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        primitive.transform.SetParent(this.transform);
        primitive.transform.localPosition = new Vector3(localX,localY,localZ);
        primitive.transform.localScale = Vector3.one;
        //Set the color of the texture at that location
        //based on the value, color the brick
        if(localZ>5){
            primitive.GetComponent<Renderer>().material.color = Color.green;
        }
        else if(localZ>4){
            primitive.GetComponent<Renderer>().material.color = new Color(90/255f, 46/255f, 38/255f);
        }
        else{
            primitive.GetComponent<Renderer>().material.color = Color.grey;
        }

        // For the mesh we actually just want a plane
        //get the top for corners of our cube
        Destroy(primitive.GetComponent<BoxCollider>());
        MeshCollider meshC = primitive.AddComponent<MeshCollider>();
        meshC.sharedMesh = planeMesh;

        primitive.layer = LayerMask.NameToLayer("Minecraft");
    }
    
}
