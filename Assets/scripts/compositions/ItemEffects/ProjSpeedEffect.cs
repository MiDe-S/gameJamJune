using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjSpeedEffect : Effect
{
    public int multiplier = 20;

    public override void ApplyTo(GameObject obj) {
        obj.GetComponent<InputController>().addProjSpeed(20);
    }
}
