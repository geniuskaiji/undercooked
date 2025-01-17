﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounder : MonoBehaviour
{
    // needs to be set wider for last room
    public Vector2 minCamBounds = new Vector2(-15.5f, -17f);

    public Vector2 maxCamBounds = new Vector2(-12f, 17f);

    public Transform followTarget;
    public bool activatedFollow = true;
    public bool boundedFollow = true;

    private float zOffset = -10f;

    public float lerpSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetXMaxBounds(float x){
        maxCamBounds.x = x;
    }

    public void SetYMaxBounds(float y) {
        maxCamBounds.y = y;
    }

    // Update is called once per frame
    void Update()
    {
        if(activatedFollow){
            Vector2 path = followTarget.position - transform.position;

           
            
            Debug.DrawRay(transform.position, path, Color.yellow); // for debugging; 

            Vector2 lerpPath = Vector2.Lerp(transform.position, followTarget.position, Time.deltaTime * lerpSpeed);

            if (boundedFollow) {

                if (lerpPath.x < minCamBounds.x) {
                    lerpPath.x = minCamBounds.x;
                } else if (lerpPath.x > maxCamBounds.x) {
                    lerpPath.x = maxCamBounds.x;
                }

                if (lerpPath.y < minCamBounds.y) {
                    lerpPath.y = minCamBounds.y;
                } else if (lerpPath.y > maxCamBounds.y) {
                    lerpPath.y = maxCamBounds.y;
                }
            }

            transform.position = new Vector3(lerpPath.x, lerpPath.y, zOffset);
        }
    }
}
