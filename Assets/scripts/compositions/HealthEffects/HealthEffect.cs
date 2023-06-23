using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthEffect : MonoBehaviour
{
    public abstract void onHealthChange(int currentHealth);
}
