using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Asteroids get distroyed automatically when they reach the
 * limit of the screen.
 */
public class AsteroidDestroy : MonoBehaviour
{
    // Asteroid explosion
    private GameObject astExplosion;

    // Asteroids explosions parent gameobject
    private GameObject astExplosionsParent;

    void Start()
    {
        // Asteroid explosion
        astExplosion = AsteroidsManager.instance.GetAsteroidExplosion(AsteroidsManager.AsteroidType.Normal);

        // Asteroids explosions parent gameobject
        astExplosionsParent = GameObject.FindWithTag(Tags.AsteroidsExplosions);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ScreenLimit))
        {
            // Asteroid not distroyed by the player
            GameManager.instance.LoseLife();

            Destroy(this.gameObject);

            GameObject explosionInstance = Instantiate(astExplosion, transform.position, transform.rotation);
            explosionInstance.transform.parent = astExplosionsParent.transform;
        }
    }

}
