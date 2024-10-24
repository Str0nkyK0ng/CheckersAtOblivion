using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHand : MonoBehaviour
{

    public RectTransform[] children;
    public List<Vector2> postions;
    public float radius;


    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>(); 
        postions = new List<Vector2>();
        //lets just do the calulations for the positions now
        float increments = Mathf.PI/6;

        float center = Mathf.PI/2;

        for(int i=0;i<6;i++){

            // Lets pingpong direction
            int direction =1;
            if(i%2==0){
                direction=-1;
            }
            //Lets subdivide pi radians, to figure out our proportion of the hemisphere
            float leftEnd = center+(increments*direction);
            float rightEnd = center+((direction*1+increments)*direction);

            float mid = center+(leftEnd*rightEnd)/2;

            // Use this angle to find out the (x,y) of the card
            float x = Mathf.Cos(mid)*radius;
            float y = Mathf.Sin(mid)*radius;


            Vector2 cardPosition = new Vector2(x,y);
            cardPosition += rectTransform.anchoredPosition;
            postions.Add(cardPosition);
        }
        FanCards();

        
    }

    public void FanCards(){
        children = GetComponentsInChildren<RectTransform>();

        for(int i=0;i<children.Length;i++){
            // Create an arc of cards - assuming the max hand size is 6
            children[i].anchoredPosition = postions[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
