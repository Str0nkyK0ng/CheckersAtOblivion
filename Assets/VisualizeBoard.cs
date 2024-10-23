using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualizeBoard : MonoBehaviour
{
    Board gameBoard;
    public float scaleSize = 0.75f/2;
    public PieceVisualization piecePrefab;
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
                    PieceVisualization piece = Instantiate(piecePrefab);
                    piece.correspondingPiece = gameBoard.grid[x][y];

                    // Change the position
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

    public void MovePiece(Piece piece, int x, int y){
        gameBoard.grid[piece.x][piece.y] = null;
        gameBoard.grid[x][y] = piece;
        piece.x = x;
        piece.y = y;
        ClearGhosts();
        SFXManager.instance.PlaySFX("Place",true);
    }



    List<GameObject> ghosts;
    public void VisualizeGhost(int x, int y, PieceVisualization piece){
        // see if that spot is already occupied
        if(gameBoard.grid[x][y]!=null){
            return;
        }
        // Create a circle
        GhostVisualization ghost = Instantiate(ghostPrefab);
        ghost.correspondingPiece = piece;
        ghost.gridPosition = new Vector2(x,y);
        ghost.transform.SetParent(this.transform);
        // white with 50% transparency
        ghost.GetComponentInChildren<Renderer>().material.color = new Color(1,1,1,0.5f);
        ghost.transform.localPosition = new Vector3(scaleSize*x,0,scaleSize*y);
        ghosts.Add(ghost.gameObject);
    }


    public void ClearGhosts(){
        foreach(GameObject ghost in ghosts){
            Destroy(ghost);
        }
        ghosts.Clear();
    }
}
