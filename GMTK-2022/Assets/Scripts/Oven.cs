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
    [SerializeField]
    GameObject alertEx;

    private bool playedDing = false;

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
            playedDing = false;
            // check player for held item
            this.item = chefPickup.heldObject;
            chefPickup.ClearOldPickup(this.item);
            timer = 0;
        }

        // Check if item is pizza
        if(item)
        {
            if (item.GetComponent<Pizza>())
            {
                this.pizza = this.item.GetComponent<Pizza>();
                this.item.transform.Translate(new Vector2(10000, 10000));
                item = null;
                Destroy(this.item);
            }
            else
            {
                // destroy item
                item = null;
                Destroy(this.item);
            }
        }

        // If item is pizza, cook pizza
        if (pizza)
        {
            pizza.cooked += pizzaCookSpeed * Time.deltaTime;
            print(pizza.cooked);
            pizza.doneCooking = true;

            if(pizza.cooked >= 100 && pizza.doneCooking)
            {
                if (!playedDing)
                {
                    playedDing = true;
                    alert.Play();
                    alertEx.SetActive(true);
                }
            }

            if (playerDistance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && !chefPickup.heldObject && timer >= .25f)
            {
                timer = 0;
                // Set boxed pizza

                GameObject cookedPizza = Instantiate(pizzaToppings).gameObject;
                cookedPizza.GetComponent<Pizza>().SetPizza(pizza);
                chefPickup.SetNewPickup(cookedPizza);
                alertEx.SetActive(false);

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
