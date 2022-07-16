using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField]
    int pizzaCookSpeed = 5;
    [SerializeField]
    GameObject player;
    PickUpTestScript chefPickup;
    GameObject item;
    Pizza pizza;
    bool isFullyCooked = false;
    [SerializeField]
    bool isDebugging = false;

    private AudioSource alert;

    void Start()
    {
        alert = GetComponent<AudioSource>();
        chefPickup = player.GetComponent<PickUpTestScript>();
    }
    
    void Update()
    {
        // Get player distance
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if(isDebugging)
        Debug.Log("Player Distance: " + playerDistance);

        // if player is within range and presses space, take item
        if(playerDistance <= 5 && Input.GetKeyDown(KeyCode.E) && chefPickup.itemHolding)
        {
            // check player for held item
            this.item = chefPickup.itemHolding;
            chefPickup.itemHolding = null;

            if (isDebugging)
            Debug.Log("We have an item in the oven!");
        }

        // Check if item is pizza
        if(item)
        {
            if (item.GetComponent<Pizza>())
            {
                this.pizza = this.item.GetComponent<Pizza>();

                if (isDebugging)
                Debug.Log("THE ITEM IS A PIZZA TOO!");
            }
            else
            {
                // destroy item
                this.item = null;

                if (isDebugging)
                    Debug.Log("Ope, it wasn't a pizza. You burned it.");
            }
        }


        // If item is pizza, cook pizza
        if (pizza)
        {
            pizza.cooked += pizzaCookSpeed * Time.deltaTime;

            if (isDebugging)
                Debug.Log("Pizza is being cooked, boys! " + pizza.cooked);

            if(pizza.cooked >= 100 && !pizza.doneCooking)
            {
                pizza.doneCooking = true;
                alert.Play();
                // Make noise, flash oven, alert player somehow
            }
        }
    }
}
