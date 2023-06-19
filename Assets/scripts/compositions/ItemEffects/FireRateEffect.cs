using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateEffect : Effect
{
    public float multiplier = 0.5f;

    public override void ApplyTo(GameObject obj) {
        obj.GetComponent<ProjectileShoot>().multiplyFireRate(multiplier);
    }
}
