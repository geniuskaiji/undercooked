using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class DrinkFridge : MonoBehaviour
{

    public bool isPlayerNearby = false;
  //  public Sprite fullFridge;
   // public Sprite emptyFridge;

    public Animator anim;
    // data about the object.
    public bool hasDrinks;
    public int numberOfDrinksRemaining;

   // public GameObject ui; //The UI, can call ui.SetActive(true) method on it

    //Defining the UnityEvents so that we can all enterTriggerEvent.invoke() later
    public UnityEvent enterTriggerEvent = new UnityEvent();
    public UnityEvent exitTriggerEvent = new UnityEvent();
    public UnityEvent getDrinkEvent = new UnityEvent();
    public UnityEvent restockDrinksEvent = new UnityEvent();
    // Start is called before the first frame update

    // --- Handle Art ---
    public SpriteRenderer fridgeBack;
    // frame index should match number of drinks
    public Sprite[] fridgeFrames;

    public PlayerInventory inv;

// Update is called once per frame
    void Update()
    {
        if (isPlayerNearby) {
            if (Input.GetButtonDown("Jump")) {
                // Activate the action of this appliance
                GetDrink();
            }
        }


        fridgeBack.sprite = fridgeFrames[numberOfDrinksRemaining];
    }
    // -- stuff here will define when the player is close by --

    public void OnTriggerEnter2D(Collider2D collision) {
        // Open UI - to show that we can activate it

        isPlayerNearby = true;
        Debug.Log("Trigger Enter");
        enterTriggerEvent.Invoke();

        anim.SetTrigger("Open");
    }

    public void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Trigger Exited");
        // Close Ui
        isPlayerNearby = false;

        exitTriggerEvent.Invoke();
        anim.SetTrigger("Closed");
    }


    public void GetDrink() {
        // if count is valid, 
        // give player the item
        // otherwise
        // show UI that the item is out. 
        if (numberOfDrinksRemaining > 0) 
        {
            // add to inventory
            inv.AddDrink();

            // play event (for audio)
            getDrinkEvent.Invoke();

            // player can get a drink
            // remove a drink from the numberOfDrinksRemaining
            numberOfDrinksRemaining = numberOfDrinksRemaining - 1;
            // if fridge is empty change art, have an error sound effect
            if (numberOfDrinksRemaining < 1) { 
                hasDrinks = false;
            }
        }
        Debug.Log("Print out a message to the console");
            
    }

    

}