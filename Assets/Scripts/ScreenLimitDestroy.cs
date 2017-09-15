using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimitDestroy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }
    }

}
