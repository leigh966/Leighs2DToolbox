using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextOpacityLinearOscillatingBehaviour : MonoBehaviour
{
    public float cycleTimeInSeconds;
    private TMPro.TextMeshProUGUI textbox;
    private float currentValue = 0f, increasePerSecond;
    private bool down;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TMPro.TextMeshProUGUI>();
        increasePerSecond = 1 / cycleTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = increasePerSecond * Time.deltaTime;
        if (down)
        {
            delta = -delta;
        }
        currentValue += delta;
        textbox.alpha = currentValue;
        if(currentValue < 0f)
        {
            down = false;
        }
        if(currentValue > 1f)
        {
            down = true;
        }
    }
}
