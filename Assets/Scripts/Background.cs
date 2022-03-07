using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float ScrollSpeed = 10.0f;
    private float ResetTiming = 5.0f;
    private float Timing = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        ResetBackground();
    }

    void ResetBackground()
    {
        Timing += Time.deltaTime;
        if (ResetTiming < Timing)
        {
            // Reset
        }
    }
}
