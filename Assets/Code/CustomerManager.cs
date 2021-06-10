using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    // Editor Variables
    public GameObject customer1;
    public CustomerMovement cus1;
    public GameObject customer2;
    public CustomerMovement cus2;
    public GameObject customer3;
    public CustomerMovement cus3;
    public GameObject customer4;
    public CustomerMovement cus4;
    public GameObject customer5;
    public CustomerMovement cus5;
    public GameObject customer6;
    public CustomerMovement cus6;

    public PlayerInventory inv;

    public int playerScore;

    // Private Variables
    private int customerIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Bring in the first customer
        NextCustomerEnter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Make the next customer enter
    public void NextCustomerEnter()
    {
        customerIndex++;

        // A bunch of if statements. Bad code, but it works.
        if (customerIndex == 1)
        {
            // first customer is special, since there is no customer 0 to disable.
            //customer0.SetActive(false);
            cus1.WalkIn();
            customer1.SetActive(true);
        }
        else if (customerIndex == 2)
        {
            //customer1.SetActive(false);
            cus2.WalkIn();
            customer2.SetActive(true);
        }
        else if (customerIndex == 3)
        {
            //customer2.SetActive(false);
            cus3.WalkIn();
            customer3.SetActive(true);
        }





    }

}
