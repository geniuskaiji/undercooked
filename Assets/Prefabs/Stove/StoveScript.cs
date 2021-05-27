using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoveScript : MonoBehaviour
{
	// Variables
	public bool isPlayerNearby;

	public bool pattyGrilling = false;
    public bool isReady = false;
	//public bool pattyReady = false; // NOTE! This variable is never actually set to false again in the script after start. Fix this!
	public float pattySideGrilling = 0; // how long it cooks per side
	public float pattyGrillingTimer = 0f;

    public float pattySideTwoGrillingTimer = 0;


    public bool firstSideIsCooking = false;
	// Editor
//	public GameObject ui;
//	public GameObject pattyArtRaw;
//	public GameObject pattyArtCooking;
	//public GameObject pattyArtCooked; // NOTE! This GameObject is never actually activated in this script.

	public UnityEvent enterTriggerEvent = new UnityEvent();
	public UnityEvent exitTriggerEvent = new UnityEvent();


    public Animator anim;

	// Set this to change the time it takes to cook a burger.
	public float burgerTimeToCookSide = 180f;

    public PlayerInventory inv;

	void Update()
	{
		// Run the Interact method when the "Jump" button is pressed down, if the player is nearby.
		if (Input.GetButtonDown("Jump") && isPlayerNearby)
		{
			Interact();
		}


		// Update timer for the current side grilling
		if (pattyGrilling)
		{
			pattyGrillingTimer += Time.deltaTime;

            if(pattySideGrilling == 1){
                pattySideTwoGrillingTimer += Time.deltaTime;
            }

            // First side, first Transition
            if( pattySideGrilling == 0 && pattyGrillingTimer > burgerTimeToCookSide/2f && !firstSideIsCooking){
                // show the burger half cooked. 
                anim.SetTrigger("RawToCooking");
                firstSideIsCooking = true;
            }

            if(pattySideGrilling == 1 && pattySideTwoGrillingTimer > burgerTimeToCookSide/2f){
                anim.SetTrigger("RawToCooking");
            }

            if(pattySideTwoGrillingTimer > burgerTimeToCookSide){
                anim.SetTrigger("CookingToCooked");
                isReady = true;
            }

        }
	}


	// Run when player is nearby
	public void OnTriggerEnter2D(Collider2D Collision)
	{
		Debug.Log("Player nearby grill");
		isPlayerNearby = true;

	//	ui.SetActive(true);
		enterTriggerEvent.Invoke();
	}

	// Run when player leaves grill
	public void OnTriggerExit2D(Collider2D Collision)
	{
		Debug.Log("Player leaves grill");
		isPlayerNearby = true;

	//	ui.SetActive(false);
		exitTriggerEvent.Invoke();
	}

    // Update to side two when timer is halfway done
    //anim.SetTrigger("CookingToCooked");

    private void Interact()
	{
		/* If no patty is on the grill, and no patty is ready, put a patty on the grill.
		 *	- pattyGrillingTimer = 0f;
		 *	- pattySideGrilling = 0;
		 *	- pattyGrilling = true;
		 * If there is a patty on the grill, and one side is cooked, flip it.
		 *	- pattyGrillingTimer = 0f;
		 *	- pattySideGrilling = 1;
		 * If there is a patty on the grill, and both sides are cooked, ready it.
		 *	- pattyGrilling = false;
		 *	- pattyReady = true; */

		if (pattyGrilling == false)
		{
			// Run AddBurger method
			AddPatty();
		}
		else if (pattyGrillingTimer >= burgerTimeToCookSide)
		{
			// Check which side is currently grilling.
            // side 1
			if (pattySideGrilling == 0)
			{
				// Run FlipBurger method.
				FlipPatty();
			}
			else
			{
				// Run ReadyBurger method.
				RemovePatty();
			}
		}
	}

	private void AddPatty()
	{
		pattyGrillingTimer = 0f;
        pattySideTwoGrillingTimer = 0;
        pattySideGrilling = 0;
        isReady = false;

		pattyGrilling = true;
        anim.SetTrigger("AddBurger");

        anim.ResetTrigger(0);
        anim.ResetTrigger(1);
        anim.ResetTrigger(2);
        anim.ResetTrigger(3);
        anim.ResetTrigger(4);
        firstSideIsCooking = false;

        //	pattyArtRaw.SetActive(true);        // Set the pattyArtRaw GameObject on
        Debug.Log("Patty Added");
	}

	private void FlipPatty()
	{
        //	pattyGrillingTimer = 0f;
        pattySideTwoGrillingTimer = 0;
		pattySideGrilling = 1;

	//	pattyArtRaw.SetActive(false);		// Set the pattyArtRaw GameObject off
	//	pattyArtCooking.SetActive(true);    // Set the pattyArtCooking GameObject on
		Debug.Log("Patty Flipped");
        anim.SetTrigger("Flip");
    }

	private void RemovePatty()
	{
		pattyGrilling = false;
		//pattyReady = true;

	//	pattyArtCooking.SetActive(false);	// Set the pattyArtCooking GameObject off
		Debug.Log("Patty Removed");

        // Done, remove Patty
        anim.SetTrigger("RemoveBurger");
        inv.AddBurger();
    }

}
