using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostVisualization : MonoBehaviour
{
    public Vector2 gridPosition;
    public PieceVisualization correspondingPiece;

    public void OnMouseOver(){
        //If the piece is hovered on
        if(Input.GetMouseButtonDown(0)){
            //If the piece is clicked on, tell the corresponding piece to move to this location
            FindObjectOfType<VisualizeBoard>().MovePiece(correspondingPiece.correspondingPiece,(int)gridPosition.x,(int)gridPosition.y);
            
        }
    }

}
