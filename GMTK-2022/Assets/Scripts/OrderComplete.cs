using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderComplete : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    PickUpV2 chefPickup;
    [SerializeField]
    Order_Handling order;
    Pizza pizza;
    [SerializeField] int pizzaToppingPenalty = 8;
    [SerializeField] int pizzaSaucePenalty = 10;
    [SerializeField] int pizzaBoxPenalty = 50;

    public int totalSuccessfulPizzas = 0;
    public int totalPizzasCompleted = 0;
    public int totalRentPayed = 0;
    public int totalDays = 0;
    public int finalDifficulty = 0;

    [SerializeField] float interactionDistance = 1f;


    [SerializeField]
    bool isDebugging = false;
    // Start is called before the first frame update
    void Start()
    {
        chefPickup = player.GetComponent<PickUpV2>();

    }

    // Update is called once per frame
    void Update()
    {
        // Pull in order from NPC
        // Pull in ingredients on Pizza
        // Compare the two

        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if (playerDistance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && chefPickup.heldObject && chefPickup.heldObject.GetComponent<Pizza>())
        {
            pizza = chefPickup.heldObject.GetComponent<Pizza>();
            // Compare to NPC order
            
            foreach (string requiredTopping in order.order)
            {
                if(!pizza.toppings.Contains(requiredTopping))
                {
                    pizza.rating -= pizzaToppingPenalty;
                }
            }

            if (!order.order.Contains(pizza.sauce))
            {
                pizza.rating -= pizzaSaucePenalty;
            }

            switch(pizza.cooked)
            {
                case 0:
                    pizza.rating -= 20;
                    break;
                case <25:
                    pizza.rating -= 15;
                    break;
                case <50:
                    pizza.rating -= 10;
                    break;
                case <75:
                    pizza.rating -= 5;
                    break;
                case <95:
                    pizza.rating -= 0;
                    break;
               case > 150:
                    pizza.rating -= 20;
                    break;
                case > 125:
                    pizza.rating -= 12;
                    break;
                case >105:
                    pizza.rating -= 5;
                    break;
                
            }

            if(!pizza.isBoxed)
            {
                pizza.rating -= pizzaBoxPenalty;
            }


            if(pizza.rating >= 80)
            {
                totalSuccessfulPizzas++;
            }
            totalPizzasCompleted++;

            totalRentPayed = GameObject.FindObjectOfType<Rent_Manager>().GetComponent<Rent_Manager>().totalRentPayed;
            totalDays = GameObject.FindObjectOfType<Rent_Manager>().GetComponent<Rent_Manager>().day;
            finalDifficulty = GameObject.FindObjectOfType<Rent_Manager>().GetComponent<Rent_Manager>().difficulty;


            GameObject.FindObjectOfType<Rent_Manager>().GetComponent<Rent_Manager>().rentPayed += pizza.rating * 2;
            GameObject.FindObjectOfType<Rent_Manager>().GetComponent<Rent_Manager>().NextPizza();

            GameObject.FindObjectOfType<TimerDecrease>().GetComponent<TimerDecrease>().CurrentTime -= 60;
            if (GameObject.FindObjectOfType<TimerDecrease>().GetComponent<TimerDecrease>().CurrentTime < 0)
                GameObject.FindObjectOfType<TimerDecrease>().GetComponent<TimerDecrease>().CurrentTime = 0;

                    if (isDebugging)
                Debug.Log("Your pizza's score was " + pizza.rating + "!");

            GameObject temp = chefPickup.heldObject;
            chefPickup.ClearOldPickup(chefPickup.heldObject);
            GameObject.Destroy(temp);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, interactionDistance);
    }
}
