using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class EnemyAttack : MonoBehaviour
{
    public int damage = 100;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Enemy")) {
            GetComponent<Attack>().attackObject(collision.gameObject, damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        OnTriggerEnter2D(collision);
    }
}
