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
            float dirX = 0;
            float dirY = 0;
            if (player.transform.position.x > transform.position.x) {
                dirX = 1;
            }
            else {
                dirX = -1;
            }

            if (player.transform.position.y > transform.position.y) {
                dirY = 1;
            }
            else {
                dirY = -1;
            }

            movement.Move(dirX, dirY);
        }
        else {
            movement.Move(0, 0);
        }
    }
}
