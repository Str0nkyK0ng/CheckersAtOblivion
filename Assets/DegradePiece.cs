using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradePiece : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float desiredLerp=100;
    public float lerp=100f;
    public float speed=1;
    void Start(){
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        DegradeManager.instance.onDegrade.AddListener(Degrade);
    }
    // Update is called once per frame
    void Update()
    {
        lerp = Mathf.Lerp(lerp,desiredLerp,Time.deltaTime*speed);
        skinnedMeshRenderer.SetBlendShapeWeight(0,lerp);
    }

    void Degrade(){
        desiredLerp += Random.Range(-DegradeReality.degration,DegradeReality.degration);
        desiredLerp = Mathf.Clamp(desiredLerp,0,100);
    }
}
