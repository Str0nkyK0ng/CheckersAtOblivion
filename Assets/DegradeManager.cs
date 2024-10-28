using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DegradeManager : MonoBehaviour
{
    public static DegradeManager instance;
    public UnityEvent onDegrade;

    public GameObject[] spawns;
    public bool doneSpawning=false;
    public int index=0;
    public void Awake(){
        instance=this;
        onDegrade=new UnityEvent();
    }
    // Update is called once per frame

    public void Degrade(){
        onDegrade.Invoke();
        DegradeReality.Increase();

        int showQ = DegradeReality.degration%2;
        if(showQ==0 && !doneSpawning){
            spawns[index].SetActive(true);
            if(index<spawns.Length){
                index++;
            }
            else{
                doneSpawning=true;
            }
        }
        
    }
}
