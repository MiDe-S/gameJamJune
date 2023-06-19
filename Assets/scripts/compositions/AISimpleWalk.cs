using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class AISimpleWalk : MonoBehaviour
{
    private GameObject player;
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            movement.Move(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        }
        else {
            movement.Move(0, 0);
        }
    }
}
