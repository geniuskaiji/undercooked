using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// version 1
public class Player : MonoBehaviour
{
    // Cache the input. 
    public float xAxisInput;
    public float yAxisInput;

    public float verticalMoveSpeedRatio = 2f / 3f;

    public float moveForce = 1f;

    // Reference to the Rigidbody to apply force for movement. 
    public Rigidbody2D rigid;


    // Update is called once per frame
    void Update()
    {
        xAxisInput = Input.GetAxis("Horizontal");
        yAxisInput = Input.GetAxis("Vertical");
    }

    // Physics update loop, used for adding force to rigidbody
    private void FixedUpdate() {
        rigid.AddForce(new Vector2(xAxisInput, yAxisInput * verticalMoveSpeedRatio) * moveForce);
    }
}
