using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The base class for all chess pieces
public class HighlightTile : MonoBehaviour
{
    public GameObject highlightPrefab;
    public static List<GameObject> highlights;
    public  static void Highlight(int x, int y){

        //Add the highlight
        GameObject go = Instantiate(highlights[0], new Vector3(x,y,-1), Quaternion.identity);
        highlights.Add(go);
    }


    public static void ClearAllHighlights(){
        foreach(GameObject go in highlights){
            Destroy(go);
        }

    }


}
