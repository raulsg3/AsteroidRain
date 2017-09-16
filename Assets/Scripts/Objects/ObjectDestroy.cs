using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Objects (only asteroids in this case) get distroyed when they reach the
 * limit of the screen or when they collide with another object.
 */
public class ObjectDestroy : MonoBehaviour {
    
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
