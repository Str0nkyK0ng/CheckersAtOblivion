using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Physical representation of a tile

public class PhysicalGridSpot : MonoBehaviour
{
    public GameObject objectOn;
    public Vector3 topLocation = new Vector3(1,0,1.5f);



    public void PlaceObject(PieceVisualization newObject){
        if(objectOn!=null){
            throw new System.Exception("Should not have two things on the same spot!");
        }
        objectOn = newObject.gameObject;
        //actually move it there
        objectOn.transform.SetParent(this.transform);

        print(topLocation);
        objectOn.transform.localPosition = topLocation;
        print(objectOn.transform.localPosition);


    }

}
