using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateEffect : Effect
{
    public float change = -2f;

    public override void ApplyTo(GameObject obj) {
        obj.GetComponent<ProjectileShoot>().addFireRate(change);
    }
}
