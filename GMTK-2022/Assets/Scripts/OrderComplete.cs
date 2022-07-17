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
    [SerializeField] int pizzaToppingPenalty = 5;
    [SerializeField] int pizzaSaucePenalty = 10;
    [SerializeField] int pizzaBoxPenalty = 30;

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

            if(!pizza.isBoxed)
            {
                pizza.rating -= pizzaBoxPenalty;
            }

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
