using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Random scale.
 */
public class AsteroidScale : MonoBehaviour
{
    // Scale range
    protected const float MinScale = 0.5f;
    protected const float MaxScale = 1.5f;

    public virtual float GetMinScale()
    {
        return MinScale;
    }

    public virtual float GetMaxScale()
    {
        return MaxScale;
    }

	void Start()
    {
        float randomScale = Random.Range(GetMinScale(), GetMaxScale());
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
	}

}
