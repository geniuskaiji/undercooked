using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageUnitScript : MonoBehaviour
{
    public bool isPlayerNearby = false;

    //object data
    public bool storageUnitclosed = true;
    //   public bool storageUnitclosing = false;

    public UnityEvent onTriggerEnterEvent = new UnityEvent();
    public UnityEvent onTriggerExitEvent = new UnityEvent();

    public PlayerInventory inven;

    public void OpenStorage ()
    {
        Debug.Log("opening storage");

        inven.AddMop();

        storageUnitclosed = false;
    }

    public void CloseStorage()
    {
        Debug.Log("closing storage");

        inven.RemoveMop();

        storageUnitclosed = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        // Open UI - to show that we can activate it

        isPlayerNearby = true;
        onTriggerEnterEvent.Invoke();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        Debug.Log("Trigger Exited");
        // Close Ui
        isPlayerNearby = false;
        onTriggerExitEvent.Invoke();
    }

    public void Update()
    {

        if (isPlayerNearby)
        {
            if (Input.GetButtonDown("Jump") )
            {
                if (storageUnitclosed)
                {

                    OpenStorage();
                }
                else
                {
                    CloseStorage();
                }
            }
        }
           
                

    }


}