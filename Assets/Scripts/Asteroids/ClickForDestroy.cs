using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForDestroy : MonoBehaviour
{

    void OnMouseDown()
    {
        PerformClick();
        Destroy(this.gameObject);
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
