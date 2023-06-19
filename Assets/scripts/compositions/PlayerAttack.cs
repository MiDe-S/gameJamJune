using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 100;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("Player")) {
            GetComponent<Attack>().attackObject(collision.gameObject, damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        OnTriggerEnter2D(collision);
    }
}
