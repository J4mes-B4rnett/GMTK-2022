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
    float interactionDistance = 1f;

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
        if(isDebugging)
        {
            OnDrawGizmos();
        }
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (playerDistance <= interactionDistance && chefPickup.heldObject && chefPickup.heldObject.GetComponent<Pizza>())
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
            else if (pizza && playerDistance <= interactionDistance && chefPickup.heldObject && !chefPickup.heldObject.GetComponent<Pizza>())
            {
                this.pizza.AddIngredient(this.chefPickup.heldObject);
                chefPickup.ClearOldPickup(this.chefPickup.heldObject);
            }
            else if(!chefPickup.heldObject && playerDistance <= interactionDistance)
            {
                chefPickup.SetNewPickup(this.pizza.gameObject);
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, interactionDistance);
    }
}
