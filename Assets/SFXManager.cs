using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource musicAudioSource;
    public static SFXManager instance;

    public Dictionary<string, AudioClip> sfx = new Dictionary<string, AudioClip>();
    public void Awake(){
        // load from resources/sfx
        AudioClip[] clips = Resources.LoadAll<AudioClip>("sfx");
        foreach (AudioClip clip in clips)
        {
            sfx[clip.name] = clip;
        }

        if(instance!=null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    public void PlaySFX(string name, bool randomPich=false){
        if(audioSource==null)
            audioSource = GetComponent<AudioSource>();
        if(randomPich)
            audioSource.pitch = Random.Range(0.9f, 1.1f);
        else
            audioSource.pitch = 1.0f;

        if(sfx.ContainsKey(name))
            audioSource.PlayOneShot(sfx[name]);
        else
            Debug.LogError("SFX not found: " + name);
    }
    public void ChangeVolume(float volume){
        audioSource.volume = volume;
        musicAudioSource.volume = volume;
    }
}
