using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnWakeBehaviour : MonoBehaviour
{
    public float startSize, endSize, time;

    private float toGrowPerSec, currentTime;

    public bool timedOut
    {
        get
        {
            return currentTime > time;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        transform.localScale = Vector3.one * startSize;
        toGrowPerSec = (endSize - startSize)/time;
        currentTime = 0f;
    }

    // Update is called once per frame
    public void Update()
    {
        if (timedOut) return;
        float deltaTime = Time.deltaTime;
        transform.localScale += Vector3.one * toGrowPerSec * deltaTime;
        currentTime += deltaTime;
    }





}
