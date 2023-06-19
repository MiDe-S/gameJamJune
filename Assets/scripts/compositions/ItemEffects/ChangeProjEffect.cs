using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProjEffect : Effect
{
    public GameObject newProj;

    public override void ApplyTo(GameObject obj) {
        obj.GetComponent<ProjectileShoot>().setProj(newProj);
    }
}
