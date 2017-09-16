using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Random larger scale.
 */
public class AsteroidScaleLarge : AsteroidScale
{
    // Larger scale range
    private const float MinScaleLarge = 1.5f;
    private const float MaxScaleLarge = 2.5f;

    public override float GetMinScale()
    {
        return MinScaleLarge;
    }

    public override float GetMaxScale()
    {
        return MaxScaleLarge;
    }

}
