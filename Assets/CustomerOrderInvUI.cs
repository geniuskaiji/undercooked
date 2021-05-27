using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomerOrderInvUI : MonoBehaviour
{
    /*
     *     // Variables
    public int pizzasOrdered;
    public int burgersOrdered;
    public int deluxeBurgersOrdered;
    public int drinksOrdered;

    public bool orderTaken = false;
    public float timeSinceOrderTaken = 0f;
*/

    [Header("Inventory Reference")]
    public NewOrder inv;

    [Header("Inventory Icons")]
    public GameObject pizzaIcon;
    //public Text pizzasText;
    public GameObject burgerIcon;
    public Text burgerCountText;
    public GameObject deluxeBurgerIcon;
    public Text deluxeBurgerCountText;
    public GameObject drinkIcon;
    public Text drinkCountText;

    [Header("Order Feedback")]
    public Text timeWaiting;

    public void Update(){

        // Pizza
        pizzaIcon.SetActive(inv.pizzasOrdered > 0);
        // Burgers
        burgerIcon.SetActive(inv.burgersOrdered > 0);
        burgerCountText.text = "" + inv.burgersOrdered;
        // Deluxe Burger
        deluxeBurgerIcon.SetActive(inv.deluxeBurgersOrdered > 0);
        deluxeBurgerCountText.text = "" + inv.deluxeBurgersOrdered;
        // Drinks
        drinkIcon.SetActive(inv.drinksOrdered > 0);
        drinkCountText.text = "" + inv.drinksOrdered;


        // Convert to int to drop the decimal places, then to String for the UI
        timeWaiting.text = "" + (int)inv.timeSinceOrderTaken;
    }
}
