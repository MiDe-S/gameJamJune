using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogicScript : MonoBehaviour
{
    private bool isOpen = false;
    private Animator anim;


    void Start() {
        anim = GetComponent<Animator>();
    }

    public void openExit() {
        isOpen = true;
        GetComponent<Animator>().SetBool("isOpen", true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isOpen && collision.gameObject.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("EventManager").GetComponent<managerScript>().exitEntered(transform.position);
        }
    }

}
