using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGameHand : MonoBehaviour
{

    public List<RectTransform> cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = GetComponentsInChildren<RectTransform>().ToList();
        // loop
        for(int i=0;i<cards.Count;i++){
            cards[i].localScale *= (-(cards.Count/2-i))+cards.Count/2;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
