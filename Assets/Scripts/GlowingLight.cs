using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlowingLight : MonoBehaviour
{
    Light2D light2D;
    float time = 0;
    bool fireup = false;

    private void Start()
    {
        light2D = this.gameObject.GetComponent<Light2D>();

    }

    private void Update()
    {
        if (fireup)
        {
            light2D.pointLightOuterRadius += 0.5f * Time.deltaTime;
        }
        else
        {
            light2D.pointLightOuterRadius -= 0.5f * Time.deltaTime;
        }

        time += Time.deltaTime;

        if ((int)time % 2 == 0)
            fireup = true;
        else
            fireup = false;
    }
}
