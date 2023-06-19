using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public List<Effect> effects;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            for (int i = 0; i < effects.Count; i++) {
                effects[i].ApplyTo(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

}
