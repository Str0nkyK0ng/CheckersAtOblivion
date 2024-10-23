using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Physical representation of a tile

public class PhysicalGridSpot : MonoBehaviour
{
    public GameObject objectOn;
    public Vector3 diff = new Vector3(0,0,0);

    public void Awake(){
        diff = new Vector3(0,transform.localScale.y,0);
    }
    public void PlaceObject(GameObject newObject){
        if(objectOn!=null){
            throw new System.Exception("Should not have two things on the same spot!");
        }
        objectOn = newObject.gameObject;
        newObject.transform.SetParent(this.transform.parent);
        //actually move it there
        UpdateObjectPosition();
    }

    public void RemoveObject(){
        objectOn = null;
    }

    public void DeleteObject(){
        Destroy(objectOn);
        objectOn = null;
    }

    public void Update(){
        UpdateObjectPosition();
    }

    public void UpdateObjectPosition(){
        if(objectOn!=null){
            Vector3 topPosition =  diff+ this.transform.localPosition;
            float heighBonus = objectOn.transform.localScale.y/3;
            topPosition.y += heighBonus;
            objectOn.transform.localPosition = topPosition;
        }
    }

}
