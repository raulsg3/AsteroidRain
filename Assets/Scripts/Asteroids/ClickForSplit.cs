using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForSplit : ClickForDestroy
{

    protected override void PerformClick()
    {
        Transform goTransform = this.gameObject.transform;
        AsteroidsManager.instance.AsteroidSplit(goTransform.position);
    }

}
