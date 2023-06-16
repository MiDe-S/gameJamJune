using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 10f;

    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    public void Move(float dirX, float dirY)
    {
        myRigidbody.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }
}
