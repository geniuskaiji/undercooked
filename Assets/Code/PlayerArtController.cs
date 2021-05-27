using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtController : MonoBehaviour
{

    // Cache the input. 
    public float xAxisInput;
    public float yAxisInput;

    // Reference to the Rigidbody to use the velocity
    //public Rigidbody2D rigid;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        // Getting input
        xAxisInput = Input.GetAxis("Horizontal");
        yAxisInput = Input.GetAxis("Vertical");

        // Updating the animators parameters. 
        anim.SetFloat("xInput", xAxisInput);
        anim.SetFloat("yInput", yAxisInput);
        if(Input.GetButtonDown("Jump")){
            anim.SetTrigger("buttonDown");
        }
    }
}
