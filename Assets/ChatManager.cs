using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{

    public string[] messages;
    public int index=0;
    public EyeballText messagePrefab;
    public Transform messageParent;


    public void AddMessage(string message){
        EyeballText go = Instantiate(messagePrefab,messageParent);
        go.desiredString = message;
    }
    public void Increment(){
        index++;
        if(index>=messages.Length){
            return;
        }
        AddMessage(messages[index]);
    }

    public void Start(){
        AddMessage(messages[index]);
        DegradeManager.instance.onDegrade.AddListener(Increment);
    }
}
