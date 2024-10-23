using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Physical representation of a tile

public class PhysicalGridSpot : MonoBehaviour
{
    public GameObject objectOn;
    public Vector3 diff = new Vector3(1,0,1.5f);

    public void PlaceObject(GameObject newObject){
        if(objectOn!=null){
            throw new System.Exception("Should not have two things on the same spot!");
        }
        objectOn = newObject.gameObject;
        newObject.transform.SetParent(this.transform.parent);
        //actually move it there
        Vector3 topPosition =  diff+ this.transform.position;
        newObject.transform.localPosition = topPosition;


    }

}
