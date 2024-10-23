using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualizeBoard : MonoBehaviour
{
    Board gameBoard;
    public float scaleSize = 0.75f/2;
    public PieceInteraction piecePrefab;
    public GhostVisualization ghostPrefab;

    List<GameObject> pieces;

    public List<PhysicalGridSpot> physicalGridSpots;
    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<GameObject>();
        ghosts = new List<GameObject>();
        gameBoard = new Board();
        physicalGridSpots = GetComponentsInChildren<PhysicalGridSpot>().ToList();
        InitializePieces();    
    }

    void InitializePieces(){
        for(int x=0;x<8;x++){   
            for(int y=0;y<8;y++){
                // Let's create all of our pieces
                if(gameBoard.grid[x][y]!=null){
                    PieceInteraction piece = Instantiate(piecePrefab);
                    piece.correspondingPiece = gameBoard.grid[x][y];

                    // Change the color of the piece
                    if(gameBoard.grid[x][y].color=="White")
                        piece.GetComponentInChildren<Renderer>().material.color = Color.red;
                    else
                        piece.GetComponentInChildren<Renderer>().material.color = Color.blue;

                    //Set it on our spot
                    physicalGridSpots[x+y*8].PlaceObject(piece.gameObject);
                    pieces.Add(piece.gameObject);
                }
            }
        }
    }

    public void MovePiece(PieceInteraction piece, Vector2 newPosition){
        // Get the current position of the piece
        int x = (int)piece.correspondingPiece.x;
        int y = (int)piece.correspondingPiece.y;
        // Get the new position of the piece
        int newX = (int)newPosition.x;
        int newY = (int)newPosition.y;
        // Move the piece
        gameBoard.grid[newX][newY] = gameBoard.grid[x][y];
        gameBoard.grid[x][y] = null;

        piece.correspondingPiece.x = newX;
        piece.correspondingPiece.y = newY;
        // Move the piece in the visualization
        ClearGhosts();
        physicalGridSpots[newX+newY*8].PlaceObject(piece.gameObject);
        physicalGridSpots[x+y*8].RemoveObject();
    }

    List<GameObject> ghosts;
    public void VisualizeGhost(int x, int y, PieceInteraction piece){
        // see if that spot is already occupied
        if(gameBoard.grid[x][y]!=null){
            return;
        }
        // Create a circle
        GhostVisualization ghost = Instantiate(ghostPrefab);
        ghost.correspondingPiece = piece;
        ghost.GetComponentInChildren<Renderer>().material.color = new Color(1,1,1,0.5f);
        physicalGridSpots[x+y*8].PlaceObject(ghost.gameObject);
        ghost.gridPosition = new Vector2(x,y);
        ghosts.Add(ghost.gameObject);
    }


    public void ClearGhosts(){
        foreach(GameObject ghost in ghosts){
            // Clear the spot on the grid
            GhostVisualization gv = ghost.GetComponent<GhostVisualization>();
            int index = (int)(gv.gridPosition.x+gv.gridPosition.y*8);
            print("Clearing ghost at "+index);
            physicalGridSpots[index].DeleteObject();
        }
        ghosts.Clear();
    }
}
