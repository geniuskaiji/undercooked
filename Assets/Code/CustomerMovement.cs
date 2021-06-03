using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float speed = 1f;
    private float moveForce = 0f;

    private bool wasAtCounter = false;

    // Editor variables
    public Rigidbody2D rigid;

    // Walk into the 
    void Start()
    {
        WalkIn(); //temporary start on play
    }

   // Walk to the counter
    public void WalkIn() 
    {
        Debug.Log("Customer walk in");
        moveForce = 1f;
    }

    // Leave the counter
    public void WalkOut()
    {
        Debug.Log("Customer walk out");
        moveForce = -1f;
    }

    // Physics update loop, used for adding force to the rigidbody
    private void FixedUpdate()
    {
        rigid.AddForce(new Vector2(speed * moveForce, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Freeze the customer's momentum the first time the customer collides with anything.
        // Change this to happen only when colliding with a counter trigger tag.
        if (!wasAtCounter)
        {
            Debug.Log("Customer is at counter");
            moveForce = 0f;

            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            wasAtCounter = true;
        }
    }
}
