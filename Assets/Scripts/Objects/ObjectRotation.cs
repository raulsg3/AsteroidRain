using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Random rotation along all three axis.
 */
public class ObjectRotation : MonoBehaviour {

    // Rotation speed range
    [Header("Rotation Speed Range")]
    public float minSpeed = 0.5f;
    public float maxSpeed = 5.0f;

	void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Random.Range(minSpeed, maxSpeed);
	}

}
