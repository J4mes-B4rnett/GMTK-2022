using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField]
    int pizzaCookSpeed = 5;
    [SerializeField]
    GameObject player;
    PickUpV2 chefPickup;
    GameObject item;
    Pizza pizza;
    [SerializeField]
    bool isDebugging = false;
    [SerializeField] float interactionDistance = .4f;
    [SerializeField] Pizza pizzaToppings;
    float timer = 0;

    private AudioSource alert;

    void Start()
    {
        alert = GetComponent<AudioSource>();
        chefPickup = player.GetComponent<PickUpV2>();
    }
    
    void Update()
    {
        // Get player distance
        float playerDistance = (player.transform.position - this.transform.position).magnitude;
        timer += 1 * Time.deltaTime;

        // if player is within range and presses space, take item
        if (playerDistance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && chefPickup.heldObject)
        {
            // check player for held item
            this.item = chefPickup.heldObject;
            chefPickup.ClearOldPickup(this.item);

            if (isDebugging)
            Debug.Log("We have an item in the oven!");
            timer = 0;
        }

        // Check if item is pizza
        if(item)
        {
            if (item.GetComponent<Pizza>())
            {
                this.pizza = this.item.GetComponent<Pizza>();

                item = null;
                GameObject.Destroy(this.item);


                if (isDebugging)
                Debug.Log("THE ITEM IS A PIZZA TOO!");
            }
            else
            {
                // destroy item
                item = null;
                GameObject.Destroy(this.item);


                if (isDebugging)
                    Debug.Log("Ope, it wasn't a pizza. You burned it.");
            }
        }

        Debug.Log(pizza);
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

            if (playerDistance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && !chefPickup.heldObject && timer >= .25f)
            {
                timer = 0;
                // Set boxed pizza
                GameObject cookedPizza = Instantiate(pizzaToppings).gameObject;
                cookedPizza.GetComponent<Pizza>().SetPizza(pizza);
                chefPickup.SetNewPickup(cookedPizza);

                this.pizza = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, interactionDistance);
    }
}
