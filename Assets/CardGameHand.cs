using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGameHand : MonoBehaviour
{
    public float bigScale=0.25f;
    public List<RectTransform> cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = GetComponentsInChildren<RectTransform>().ToList();
        float half = (cards.Count-1)/2;
        // loop
        for(int i=0;i<cards.Count;i++){
            if(cards[i].gameObject == this.gameObject){
                continue;
            }
            else{
                float index = i-1;
                float scale = - Mathf.Abs(half-index)+half+1;
                cards[i].localScale *= scale*bigScale;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
