using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextOpacitySinOscillatingBehaviour : MonoBehaviour
{
    public float cycleTimeInSeconds;
    private TMPro.TextMeshProUGUI textbox;
    private float increasePerSecond, currentValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TMPro.TextMeshProUGUI>();
        increasePerSecond = (2f * Mathf.PI)/cycleTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += increasePerSecond * Time.deltaTime;
        textbox.alpha = (Mathf.Sin(currentValue)+1f)/2f;
    }
}
