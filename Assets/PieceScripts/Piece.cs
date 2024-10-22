using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{

    public int x,y;
    public string color;
    public bool isPromoted=false;
    private int forward = 1;


    public Piece(int x,int y, string color){
        this.x=x;
        this.y=y;
        this.color=color;
        if(color=="Black"){
            forward = 1;
        }
        else{
            forward = -1;
        }
    }

    public List<Vector2> GetMoves(){
        List<Vector2> options = new List<Vector2>();
        // We are interested in checking the two diagonals in the "FORWARD" direction

        //The forward diags
        Vector2 forwardLeftDiagonal = new Vector2(1,forward);
        if(Board.IsValidPosition(forwardLeftDiagonal+new Vector2(x,y))){
            options.Add(forwardLeftDiagonal+new Vector2(x,y));
        }
        Vector2 forwardRightDiagonal = new Vector2(-1,forward);
        if(Board.IsValidPosition(forwardRightDiagonal + new Vector2(x,y))){
            options.Add(forwardRightDiagonal+new Vector2(x,y));
        }

        if(isPromoted){
            Vector2 backLeftDiagonal = new Vector2(1,-forward);
            if(Board.IsValidPosition(backLeftDiagonal+new Vector2(x,y))){
                options.Add(backLeftDiagonal+new Vector2(x,y));
            }
            Vector2 backRightDiagonal = new Vector2(-1,-forward);
            if(Board.IsValidPosition(backRightDiagonal+new Vector2(x,y))){
                options.Add(backRightDiagonal+new Vector2(x,y));
            }
        }

        return options;
    }
}

