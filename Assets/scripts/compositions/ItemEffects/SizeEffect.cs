using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEffect : Effect
{
    public float size_change = 0.8f;

    public override void ApplyTo(GameObject obj) {
        obj.transform.localScale = obj.transform.localScale * size_change;
    }
}
