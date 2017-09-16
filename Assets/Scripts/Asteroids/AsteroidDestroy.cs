using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Asteroids get distroyed automatically when they reach the
 * limit of the screen.
 */
public class AsteroidDestroy : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScreenLimit"))
        {
            Destroy(this.gameObject);
        }
    }

}
