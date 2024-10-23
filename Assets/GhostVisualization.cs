using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostVisualization : MonoBehaviour
{
    public Vector2 gridPosition;
    public PieceInteraction correspondingPiece;

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            SFXManager.instance.PlaySFX("Place",true);
            //If the piece is clicked on
            FindObjectOfType<VisualizeBoard>().ClearGhosts();
            FindObjectOfType<VisualizeBoard>().MovePiece(correspondingPiece,gridPosition);
        }
    }

}
