using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Asteroids get distroyed when they reach the limit of the
 * screen or when they collide with another object.
 */
public class AsteroidDestroy : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScreenLimit"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
