using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundBehaviour : MonoBehaviour
{
    [Serializable]
    public struct NamedClip
    {
        public string name;
        public AudioClip clip;
    }

    public NamedClip[] AudioClips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip GetClip(string clipName)
    {
        foreach(var clipRecord in AudioClips) 
        {
            if(clipRecord.name == clipName)
            {
                return clipRecord.clip;
            }
        }
        Debug.LogError("Audio clip "+ clipName +" not found!");
        return null;
    }

    public void PlayClip(string clipName)
    {
        var clip = GetClip(clipName);
        if(clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
