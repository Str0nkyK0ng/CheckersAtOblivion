using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler{

    Vector3 scale;
    public void Start(){
        scale = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData){
        transform.localScale= scale* 0.95f;
    }
    public void OnPointerDown(PointerEventData eventData){
        transform.localScale= scale* 0.9f;
    }
    public void OnPointerExit(PointerEventData eventData){
        transform.localScale = scale;
    }

}
