using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ConstantBackgroundMusic : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        var music = GameObject.FindObjectsOfType<ConstantBackgroundMusic>();
        foreach(ConstantBackgroundMusic musicScript in music)
        {
            if(musicScript != this)
            {
                Destroy(musicScript.gameObject);
            }
        }
    }

}
