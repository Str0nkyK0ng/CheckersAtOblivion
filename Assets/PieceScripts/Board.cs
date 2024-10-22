using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

A checker board is played on an 8x8 grid.

We will represent this in a 2D array


We will say (0,0) is the bottom left corner of the board
This side will be WHITE - making the direction it moves in the positive y direction
With (7,7) being the top right corner
This side will be BLACK - making the direction it moves in the negative y direction
*/


public class Board
{
    public  static bool IsValidPosition(Vector2 pos){
        return pos.x>=0 && pos.x<8 && pos.y>=0 && pos.y<8;
    }

    public List<List<Piece>> grid;
    public int width=8;
    public int height=8;

    public Board(){
        grid = new List<List<Piece>>();
        for(int r=0;r<8;r++){
            grid.Add(new List<Piece>());
            for(int c=0;c<8;c++){
                grid[r].Add(null);
            }
        }
        InitBoard();
    }

    public void InitBoard(){
        //Top rows (7,6,5) are where pieces are placed
        for(int y=7;y>4;y--){
            int gap = 7-y;
            for(int x=0;x<8;x++){
                bool isGap = (gap+x)%2==0;
                if(!isGap){
                    grid[x][y] = new Piece(x,y,"White");
                }
            }
        } 


        //Bottom Rows (0,1,2)are where pieces are placed
        for(int y=0;y<3;y++){
            int gap = y+1;
            for(int x=0;x<8;x++){
                bool isGap = (gap+x)%2==0;
                if(!isGap){
                    grid[x][y] = new Piece(x,y,"Black");
                }
            }
        } 
    }   

    public string Visualize(){
        string s="";
        for(int r=0;r<8;r++){
            s+="\n";
            for(int c=0;c<8;c++){
                if(grid[r][c]!=null){
                    s+="["+grid[r][c].color+"]";
                }else{
                    s+="[ ]";
                }
            }
        }
        return s;
    }
}
