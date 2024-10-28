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
                float value = ValueFromPosition(x,y);
                CreateBlock(x,y,value);
                CheckBigDrops(x,y);
            }
        }
    }

    public int ValueFromPosition(int x, int y){
        float value;
        //two octaves of noise
        value = Mathf.PerlinNoise(x/10f,y/10f);
        value += Mathf.PerlinNoise(x/5f,y/5f);
        value /= 2;
        value*=10;

        value = Mathf.RoundToInt(value);
        return (int)value;
    }

    public void CheckBigDrops(int x,int y){
        int thisValue = ValueFromPosition(x,y);

        int leftDiff = Mathf.Abs(thisValue-ValueFromPosition(x-1,y));
        int rightDiff = Mathf.Abs(thisValue-ValueFromPosition(x+1,y));
        int upDiff = Mathf.Abs(thisValue-ValueFromPosition(x,y+1));
        int downDiff = Mathf.Abs(thisValue-ValueFromPosition(x,y-1));

        if(leftDiff>1 || rightDiff>1 || upDiff>1 || downDiff>1){
            print("Filling big drop at "+x+","+y);
            CreateBlock(x,y,thisValue-1,false);
        }
    }

    public void CreateBlock(float localX, float localY, float localZ, bool hasCollider=true){
        //Create a primitve at that location (x,y,value*10)
        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        primitive.transform.SetParent(this.transform);
        primitive.transform.localPosition = new Vector3(localX,localY,localZ);
        primitive.transform.localScale = Vector3.one;
        //Set the color of the texture at that location
        //based on the value, color the brick
        if(localZ>3){
            primitive.GetComponent<Renderer>().material.color = Color.green;
        }
        else if(localZ>1){
            primitive.GetComponent<Renderer>().material.color = new Color(90/255f, 46/255f, 38/255f);
        }
        else{
            primitive.GetComponent<Renderer>().material.color = Color.grey;
        }
        // we dont want backface
        primitive.GetComponent<Renderer>().material.SetFloat("_Mode", 2);

        // For the mesh we actually just want a plane
        //get the top for corners of our cube
        Destroy(primitive.GetComponent<BoxCollider>());
        if(hasCollider){
            MeshCollider meshC = primitive.AddComponent<MeshCollider>();
            meshC.sharedMesh = planeMesh;
        }

        primitive.layer = LayerMask.NameToLayer("Minecraft");
    }
    
}
