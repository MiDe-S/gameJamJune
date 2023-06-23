using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : Effect
{
    public float speed_change = 4f;

    public override void ApplyTo(GameObject obj) {
        obj.GetComponent<Movement>().addMoveSpeed(speed_change);
    }
}
