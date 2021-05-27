using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PizzaOven : MonoBehaviour
{
    public bool isPlayerNearby = false;

    public bool hasPizza = false;

    public int count;

    public PlayerInventory inv;

    public Animator anim;

    public UnityEvent addEvent = new UnityEvent();
    public UnityEvent removeEvent = new UnityEvent();
    public UnityEvent handsFull = new UnityEvent();// tries to pick up but hands are full

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby)
        {

            if (Input.GetButtonDown("Jump"))
            {
                // Activate the action of this appliance
                if (hasPizza)
                {
                    removePizza();
                }
                else
                {
                    addPizza();
                    // Gives you Pizza if you don't have any
                }
            }
        }
    }

    public void addPizza() {
        hasPizza = true;

        anim.SetBool("hasPizza", true);
        addEvent.Invoke();
        // if count is valid, 
        // give player the item
        // otherwise
        // show UI that the item is out. 

        Debug.Log("Adding Pizza Pizza");
    }

    private void removePizza() {
        
        // If true, we s7uccessfully added the pizza
        if(inv.AddPizza()){
            // Write the code that does the pizza here.
            hasPizza = false;
            anim.SetBool("hasPizza", false);
            removeEvent.Invoke();
        } else{
            Debug.Log("Players hands are full, can't pick up pizza");
            handsFull.Invoke();
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Open UI - to show that we can activate it

        isPlayerNearby = true;

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // Close Ui
        isPlayerNearby = false;
    }

   
}
