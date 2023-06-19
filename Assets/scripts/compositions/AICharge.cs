using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharge : MonoBehaviour
{
    private GameObject player;
    private Movement movement;
    public float chargeCoolDown = 60f;
    private float currentCoolDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentCoolDown = chargeCoolDown;
        player = GameObject.FindWithTag("Player");
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCoolDown > 0) {
            currentCoolDown -= 60 * Time.deltaTime;
        }
        else if (player != null) {
            currentCoolDown = chargeCoolDown;
            movement.Move(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        }
    }
}
