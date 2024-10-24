using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EyeballText : MonoBehaviour
{

    public TextMeshProUGUI textMesh;

    string gameChars = "♠♥♣♦";
    //♔♕♖♗♚♛♜♝♞♟♘♙🂦

    public string desiredString="";
    public string displayString="";
    public int correctChars=0;

    [Header ("Freq")]
    public float frequency=1;
    private float timer=0;

    public void RandomizeString(){
        if(correctChars!=desiredString.Length){
            correctChars++;
        }

        displayString="";
        int incorrectChars = desiredString.Length-correctChars;

        for(int i=0;i<desiredString.Length;i++){
            int denominator = Random.Range(1,desiredString.Length-i);
            //skip any spaces
            if(desiredString[i]==' '){
                displayString+=" ";
                continue;
            }
            if(denominator<=incorrectChars){
                print("True");
                displayString+=gameChars[Random.Range(0,gameChars.Length)];
                incorrectChars--;
            }
            else{
                displayString+=desiredString[i];
            }
        }

        textMesh.text ="<color=white>[01:24]</color> <color=red>[All] Ey3B4ll (Eyeball):</color><color=white>"+displayString+"</color>";
    }
    

    public void Start(){
        textMesh = GetComponent<TextMeshProUGUI>();
        RandomizeString();
    }

    public void Update(){
        timer+=Time.deltaTime;
        if(timer>1f/frequency){
            timer=0;
            if(desiredString!=displayString){
                RandomizeString();
            }
        }
    }

    public void SetString(string str){
        // desiredString = "<color=white>[01:24]</color> <color=red>[All] Ey3B4ll (Eyeball):</color><color=white>"+str+"</color>";
        desiredString = str;
        correctChars=0;
        RandomizeString();
    }

}
