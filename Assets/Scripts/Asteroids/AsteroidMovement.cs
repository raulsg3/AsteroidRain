using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Movement along the Y axis with random speed.
 */
public class AsteroidMovement : MonoBehaviour
{
    // Movement speed range
    [Header("Movement Speed Range")]
    public float minSpeed = 0.5f;
    public float maxSpeed = 3.0f;

	void Start()
    {
        GetComponent<Rigidbody>().velocity = -transform.up * Random.Range(minSpeed, maxSpeed);
	}

}
