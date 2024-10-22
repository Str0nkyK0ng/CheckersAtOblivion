using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PieceVisualization : MonoBehaviour
{

    public Piece correspondingPiece;
    public float scaleSize = 0.75f/2;

    public bool selected=false;


    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            //If the piece is clicked on
            selected=!selected;
            if(selected){
                FindObjectOfType<VisualizeBoard>().ClearGhosts();
                DisplayPossibleMoves();
            }
            else{
                FindObjectOfType<VisualizeBoard>().ClearGhosts();
            }
        }
    }

    public void MoveTo(int x,int y){
        selected=false;
    }   


    public void DisplayPossibleMoves(){
        List<Vector2> moves = correspondingPiece.GetMoves();
        foreach(Vector2 move in moves){
            FindObjectOfType<VisualizeBoard>().VisualizeGhost((int)move.x,(int)move.y,this);
        }
    }

}
