using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Variables
    public bool hasPizza = false;
    public int burgers;
    public int drinks;
    public int deluxeBurgers = 0;
    public bool hasTrash = false;
    public bool hasMop = false;
    
    public void AddMop(){

        if( hasPizza || burgers > 0 || drinks > 0 || deluxeBurgers > 0 || hasTrash )
        {
            Debug.Log("Can't pick up mop while my hands are full");
        }
        else
        {
            Debug.Log("Picked Up Mop");
            hasMop = true;
        }

    }

    public void RemoveMop()
    {
        hasMop = false;
    }

    public bool UpgradeBurger(){
        if( burgers > 0){
            burgers--;
            deluxeBurgers++;
            return true;
        }else{
            // no burgers found
            return false;
        }
    }

    // 
    public bool AddPizza()
    {
        if ( burgers > 0 || deluxeBurgers > 0 || drinks > 1 || hasTrash )
        {
            Debug.Log("Can't pick up a pizza with a burger in your hand");
            return false;
        }
        else
        {
            hasPizza = true;
            return true;
        } 
    }

    public bool HasPizza()
    {
        return hasPizza;
    }

    public bool RemovePizza()
    {

        if (hasPizza )
        {
            hasPizza = false;
            return true;
        }
        else
        {
            Debug.Log("No Pizza to remove");
            return false;
        }
    }


    // Methods
    // Adding a burger to the Inventory
    public void AddBurger()
    {
        // first enter your pin number
        // Statement within the method
        if(burgers > 1 || deluxeBurgers > 1 || drinks > 1 || hasPizza || ( burgers + drinks + deluxeBurgers > 1 ) || hasTrash )
        {
           // We are full and can't take the burger. 
        }
        else
        {
            burgers++;
        }
        
        Debug.Log("Added a burger");
        // Update the UI
        // Play sound effect
        // update the art
        // 
    }

    // Accessor
    // () parameter list
    //{ begin method
    // } end method
    public bool HasBurger() // Unused method
    {
        return (burgers > 0);
        /*
        if(burgers > 0){
            return true;
        }else{
            return false;
        }*/
    }

    public bool RemoveBurger()
    {
        if(burgers > 0)
        {
            burgers--;
            Debug.Log("Burger Removed");
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool HasDeluxeBurger() // Unused method
    {
        return (deluxeBurgers > 0);
    }

    public bool RemoveDeluxeBurger()
    {
        if (deluxeBurgers > 0)
        {
            deluxeBurgers--;
            Debug.Log("Deluxe Burger Removed");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddDrink()
    {
        // first enter your pin number
        // Statement within the method
        if ( burgers > 1 || drinks > 1 || hasPizza || ( burgers + drinks + deluxeBurgers > 1 ) || hasTrash )
        {
            // We are full and can't take the drink. 
        }
        else
        {
            drinks++;
        }

        Debug.Log("Added a drink");
        // Update the UI
        // Play sound effect
        // update the art
        // 
    }

    public bool RemoveDrink()
    {
        if (drinks > 0)
        {
            drinks--;
            Debug.Log("Drink Removed");
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
    // Coding samples
    public void ContrivedExample(){
        int c = AddNums(3, 4); // 7

        int d = AddNums(7, 8);

        int e = AddNums(8, 9);
    }

    public int AddNums(int a, int b){
        int sum = a + b;
        Debug.Log(sum + " " + a + " + " + b);
        return a + b;
    }
    */
}
