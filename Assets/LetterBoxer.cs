using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBoxer : MonoBehaviour
{
    //If the aspect ratio is not 16:9, letterbox the ui by putting black bars

    public void Start(){
        float aspect = (float)Screen.width / (float)Screen.height;
        if(aspect < 16f/9f){
            float newWidth = 16f/9f * Screen.height;
            float barWidth = (Screen.width - newWidth)/2;
            RectTransform rt = GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(barWidth,0);
            rt.offsetMax = new Vector2(-barWidth,0);
        }
        
    }
}
