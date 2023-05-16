using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMechanics : MonoBehaviour
{
    public bool emitting;

    private Renderer LEDRenderer;
    private Light spotlight;

    private void Awake()
    {
        LEDRenderer = transform.Find("LED").GetComponent<Renderer>();
        spotlight = transform.GetComponentInChildren<Light>();
    }

    public void toggleEmission()
    {
        emitting = !emitting;

        LEDRenderer.material.SetColor("_EmissionColor", emitting ? Color.white : Color.black);

        spotlight.enabled = emitting;
    }
}
