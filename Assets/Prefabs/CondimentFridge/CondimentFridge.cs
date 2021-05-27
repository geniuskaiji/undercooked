using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CondimentFridge : MonoBehaviour
{
    // State Variables
    public bool isPlayerNearby = false;
    public bool noCondiments = false;
    public bool hasCondiments = false;
    public bool isOpen = false;
    // References
    public Animator anim;

    // Art Variables
    public SpriteRenderer FridgeSprite;
    public Sprite FullFridge;
    public Sprite EmptyFridge;
    //public Sprite OpenedFridge;
    //public Sprite ClosedFridge;

    // Count Of Condiments
    public int numberOfCondiments;
    int maxStock = 8;

    public PlayerInventory inv;

    // Unity Events controlled by player
    public UnityEvent enterTriggerEvent = new UnityEvent();
    public UnityEvent exitTriggerEvent = new UnityEvent();
    public UnityEvent restockCondimentEvent = new UnityEvent();
    public UnityEvent removeCondimentEvent = new UnityEvent();
    public UnityEvent openFridgeEvent = new UnityEvent();
    public UnityEvent closeFridgeEvent = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby) {
            if (Input.GetButtonDown("Jump"))
            {
                if (isOpen)
                {
                    if (numberOfCondiments < 1)
                    {
                        RestockCondiments();
                    }
                    else
                    {
                        //CloseFridge();
                        GiveCondiment();
                        // Close Fridge
                        Debug.Log("switched Frame");
                    }
                }
                else
                {
                   // OpenFridge();
                    // Open Fridge
                    Debug.Log("switched Frame");
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        // Open UI - to show that we can activate it
        OpenFridge();
        isPlayerNearby = true;
        Debug.Log("PlayerIsNearby");
        enterTriggerEvent.Invoke();
    }

    public void OnTriggerExit2D(Collider2D collision) {
        // Close Ui
        isPlayerNearby = false;
        Debug.Log("PlayerIsNotNearby");
        exitTriggerEvent.Invoke();
        CloseFridge();
    }
    public void GiveCondiment()
    {
        // if count is valid, 
        // give player the item
        // otherwise
        // show UI that the item is out
        if (numberOfCondiments > 0)
        {

            if(inv.UpgradeBurger()){
                Debug.Log("Burger is now deluxe");
            }else{
                Debug.Log("No Burger in inventory");
            }

            //FridgeSprite.sprite = FullFridge;**
            // player can get condiment 
            // remove a condiment from the numberOfCondiments
            numberOfCondiments = numberOfCondiments - 1;
            Debug.Log("Gave Condiment");
            // if fridge is empty change art,
            if (numberOfCondiments < 1)
            {
                //FridgeSprite.sprite = EmptyFridge;**
            }
            
            removeCondimentEvent.Invoke();

        }
    }
    public void OpenFridge() {
        Debug.Log("Fridge Opened");
        isOpen = true;
        // FridgeSprite.sprite = OpenedFridge;
        anim.SetTrigger("OpenFridge");
        openFridgeEvent.Invoke();
    }
    public void CloseFridge()
    {
        Debug.Log("Fridge Closed");
        isOpen = false;
        // FridgeSprite.sprite = ClosedFridge;
        anim.SetTrigger("CloseFridge");
        closeFridgeEvent.Invoke();
    }
    public void RestockCondiments() {
        if (numberOfCondiments < 1)
        {
            numberOfCondiments = maxStock;
            restockCondimentEvent.Invoke();
        }        
        }

    } 
