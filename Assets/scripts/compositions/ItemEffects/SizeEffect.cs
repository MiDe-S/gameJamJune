using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEffect : Effect
{
    public float multiplier = 0.5f;

    public override void ApplyTo(GameObject obj) {
        obj.transform.localScale = obj.transform.localScale * multiplier;
    }
}
