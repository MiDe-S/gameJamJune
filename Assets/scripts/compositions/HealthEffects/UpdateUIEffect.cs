using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUIEffect : HealthEffect
{
    private healthUIManager healthUI;
    void Start() {
        healthUI = GameObject.FindWithTag("HealthUI").GetComponent<healthUIManager>();
    }

    public override void onHealthChange(int currentHealth) {
        healthUI.updateHealth(currentHealth);
    }
}
