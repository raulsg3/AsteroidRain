using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float secondsToDestroy = 3f;

	void Start()
    {
        Destroy(gameObject, secondsToDestroy);
	}
	
}
