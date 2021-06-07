using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageRoom : MonoBehaviour
{
    public bool isPlayerNearby = false;
    public bool hasRestockBox = false;
    // References
    public PlayerInventory inv;
    // Unity events 
    public UnityEvent enterTriggerEvent = new UnityEvent();
    public UnityEvent exitTriggerEvent = new UnityEvent();

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
                GiveRestockBox();
            }

            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerNearby = true;
        Debug.Log("PlayerIsNearby");
        enterTriggerEvent.Invoke();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerNearby = false;
        Debug.Log("PlayerIsNotNearby");
        exitTriggerEvent.Invoke();
    }

    public void GiveRestockBox()
    {
        if (inv.AddRestockBox())
        {
            Debug.Log("Player now has Restock Box");
            hasRestockBox = false;
        }
        else
        {
            Debug.Log("Player has stuff in Inventory/can't pick up RestockBox");
            
        }
    }
}

