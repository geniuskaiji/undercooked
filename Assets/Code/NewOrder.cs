using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrder : MonoBehaviour
{
    // Variables
    public int pizzasOrdered;
    public int burgersOrdered;
    public int deluxeBurgersOrdered;
    public int drinksOrdered;

    public bool orderTaken = false;
    public float timeSinceOrderTaken = 0f;

    // Editor Variables
    public int minPizzasCanOrder = 0; // Minimum number of pizzas that can be ordered by the customer (inclusive)
    public int minBurgersCanOrder = 0; // Minimum number of burgers that can be ordered by the customer (inclusive)
    public int minDeluxeBurgersCanOrder = 0; // Minimum number of burgers that can be ordered by the customer (inclusive)
    public int minDrinksCanOrder = 0; // Minimum number of drinks that can be ordered by the customer (inclusive)

    public int maxPizzasCanOrder = 2; // Maximum number of pizzas that can be ordered by the customer (exclusive)
    public int maxBurgersCanOrder = 2; // Maximum number of burgers that can be ordered by the customer (exclusive)
    public int maxDeluxeBurgersCanOrder = 2; // Maximum number of burgers that can be ordered by the customer (exclusive)
    public int maxDrinksCanOrder = 2; // Maximum number of drinks that can be ordered by the customer (exclusive)

    public PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Increase timeSinceOrderTaken if order has been taken
        if (orderTaken)
        {
            timeSinceOrderTaken += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player near customer");
        if ( orderTaken == false )
        {
            GenerateNewOrder();
            orderTaken = true;
        }
        else
        {
            ReceiveOrder();
        }

        //inventory.AddBurger();
    }
    /*private void ReceiveOrder( int drinksReceived, int burgersReceived, int pizzasReceived)
    {
        // Receive drinks from player if drinks were ordered.
        //if ( drinksOrdered > 0 )
        //{ 
        //    
        //}
    //if ( (drinksReceived >= drinksOrdered) && (dr) )
    } */

    private void ReceiveOrder()
    {

        if ( inventory.RemovePizza() ) // Run RemovePizza() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Pizza given to customer");
            pizzasOrdered--;
        }


        if ( inventory.RemoveBurger() ) // Run RemoveBurger() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Burger given to customer");
            burgersOrdered--;
        }


        if ( inventory.RemoveDrink() ) // Run RemoveDrink() from PlayerInventory.cs on the player
        {
            Debug.Log("1 Drink given to customer");
            drinksOrdered--;
        }

        // Check if order is complete
        if ( (pizzasOrdered == 0) && (burgersOrdered == 0) && (drinksOrdered == 0))
        {
            Debug.Log("Customer order complete");
        }
    }

    private void GenerateNewOrder()
    {
        // Generate the random numbers of each item ordered
        pizzasOrdered = Random.Range(minPizzasCanOrder, maxPizzasCanOrder); // Order a random number of pizzas
        burgersOrdered = Random.Range(minBurgersCanOrder, maxBurgersCanOrder); // Order a random number of burgers
        drinksOrdered = Random.Range(minDrinksCanOrder, maxDrinksCanOrder); // Order a random number of drinks


        // Check if the order was completely empty
        if ((pizzasOrdered == 0) && (burgersOrdered == 0) && (drinksOrdered == 0))
        {
            Debug.Log("Warning: Order contained no items. Defaulting to order of one burger. (Make sure the customer orders at least one item!)");
            burgersOrdered = 1;
        }


        Debug.Log("New Order Generated - " + pizzasOrdered + " pizzas, " + burgersOrdered + " burgers, " + drinksOrdered + " drinks");

        // Return these variables?
    }
}
