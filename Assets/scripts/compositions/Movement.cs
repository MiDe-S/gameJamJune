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
        float normalizer = System.Math.Max(System.Math.Abs(dirX), System.Math.Abs(dirY));
        dirX = normalizer != 0 ? dirX / normalizer : 0;
        dirY = normalizer != 0 ? dirY / normalizer : 0;
        myRigidbody.velocity = new Vector2(dirX * moveSpeed, dirY  * moveSpeed);
    }

    public void setMoveSpeed(float speed) {
        moveSpeed = speed;
    }

    public void addMoveSpeed(float speed) {
        moveSpeed = moveSpeed + speed;
    }
}
