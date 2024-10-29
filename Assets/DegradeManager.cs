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


    public float timer=5;
    public float time=0;
    public void Awake(){
        instance=this;
        onDegrade=new UnityEvent();
        // disable
        spawns.ToList().ForEach(x=>x.SetActive(false));
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
                if(index>=spawns.Length){
                    doneSpawning=true;
                }
            }
            else{
                doneSpawning=true;
            }
        }
    }

    public void Update(){
        if(doneSpawning){
            time+=Time.deltaTime;
            if(time>timer){
                time=0;
                onDegrade.Invoke();
                DegradeReality.Increase();
            }
        }

        if(DegradeReality.degration>=50){
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
