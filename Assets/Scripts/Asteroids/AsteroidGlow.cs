using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Glow effect by changing the asteroid material and the emissive color.
 */
public class AsteroidGlow : MonoBehaviour
{
    // Emissive color related constants
    private Color EmissiveBaseColor = Color.red;
    private const float MinEmissionValue = 0.6f;
    private const float MaxEmissionValue = 1.0f;

    // Asteroid final material
    private Material asteroidMaterial;

    void Start()
    {
        // Change the material
        GameObject astChild = transform.GetChild(0).gameObject;
        Renderer astChildRenderer = astChild.GetComponent<Renderer>();

        GameObject astGrandchild = astChild.transform.GetChild(0).gameObject;
        Renderer astGrandchildRenderer = astGrandchild.GetComponent<Renderer>();

        astChildRenderer.material = astGrandchildRenderer.material;
        asteroidMaterial = astChildRenderer.material;
    }

    void Update()
    {
        // Change the emissive color
        float emissionValue = Mathf.PingPong(Time.time, MaxEmissionValue - MinEmissionValue);
        Color emissiveColor = EmissiveBaseColor * Mathf.LinearToGammaSpace(emissionValue);

        asteroidMaterial.SetColor("_EmissionColor", emissiveColor);
    }

}
