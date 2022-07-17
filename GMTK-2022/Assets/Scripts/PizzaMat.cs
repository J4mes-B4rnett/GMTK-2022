using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMat : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Transform pizzaSpot;
    PickUpV2 chefPickup;
    GameObject item;
    Pizza pizza;

    [SerializeField]
    bool isDebugging = false;
    // Start is called before the first frame update
    void Start()
    {
        pizzaSpot = this.gameObject.transform.parent.transform.Find("PizzaRestingSpot");
        chefPickup = player.GetComponent<PickUpV2>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if (playerDistance <= 1 && Input.GetKeyDown(KeyCode.E) && chefPickup.heldObject.GetComponent<Pizza>())
        {
            // check player for held item
            this.item = chefPickup.heldObject;
            chefPickup.ClearOldPickup(this.item);
            this.item.transform.position = pizzaSpot.position;
            this.pizza = this.item.GetComponent<Pizza>();

            if (isDebugging)
                Debug.Log("There is a pizza on the mat.");
        }

        // TODO this logic probably needs reworked. Object should NOT be pizza but SHOULD be ingredient.
        if(Input.GetKeyDown(KeyCode.E) && pizza && playerDistance <= 1 && !chefPickup.heldObject.GetComponent<Pizza>())
        {
            this.pizza.AddIngredient(this.chefPickup.heldObject);
            chefPickup.ClearOldPickup(this.chefPickup.heldObject);
        }
    }
}
