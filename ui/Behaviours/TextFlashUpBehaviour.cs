using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TextFlashUpBehaviour : MonoBehaviour
{
    public float fadeInTime, fadeOutTime;
    TMPro.TextMeshProUGUI text;

    bool fadingIn = false, fadingOut = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadingOut)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / fadeOutTime));
            if(text.color.a <= 0 ) fadingOut = false;
        }
        if(fadingIn)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / fadeInTime));
            if(text.color.a >= 1)
            {
                fadingIn = false;
                fadingOut = true;
            }
        }
    }

    public void ShowMessage(string message)
    {
        text.text = message;
        fadingOut = false;
        fadingIn = true;
    }

}
