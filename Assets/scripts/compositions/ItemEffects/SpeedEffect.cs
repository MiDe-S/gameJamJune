using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : Effect
{
    public float multiplier = 2f;

    public override void ApplyTo(GameObject obj) {
        obj.GetComponent<Movement>().multiplyMoveSpeed(multiplier);
    }
}
