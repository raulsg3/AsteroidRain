using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForDestroy : MonoBehaviour
{
    // Asteroid explosion
    private GameObject astExplosion;

    // Asteroids explosions parent gameobject
    private GameObject astExplosionsParent;

    void Start()
    {
        // Asteroid explosion
        astExplosion = GetExplosion();

        // Asteroids explosions parent gameobject
        astExplosionsParent = GameObject.FindWithTag(Tags.AsteroidsExplosions);
    }

    void OnMouseDown()
    {
        PerformClick();
        Destroy(this.gameObject);

        GameObject explosionInstance = Instantiate(astExplosion, transform.position, transform.rotation);
        explosionInstance.transform.parent = astExplosionsParent.transform;
    }

    /**
     * Return the specific explosion for this gameobject.
     */
    protected virtual GameObject GetExplosion()
    {
        return AsteroidsManager.instance.GetAsteroidExplosion(AsteroidsManager.AsteroidType.Normal);
    }

    /**
     * Perform all required actions after the player clicks
     * on an asteroid.
     */
    protected virtual void PerformClick()
    {
        AsteroidsManager.instance.AsteroidDistroyed();
    }

}
