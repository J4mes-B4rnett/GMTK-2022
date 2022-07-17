using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBox : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    PickUpV2 chefPickup;
    Pizza pizza;
    [SerializeField]
    GameObject pizzaBox;
    Pizza boxedPizza;

    [SerializeField]
    bool isDebugging = false;
    // Start is called before the first frame update
    void Start()
    {
        chefPickup = player.GetComponent<PickUpV2>();
        boxedPizza = pizzaBox.GetComponent<Pizza>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if (playerDistance <= 1 && Input.GetKeyDown(KeyCode.E) && chefPickup.heldObject && chefPickup.heldObject.GetComponent<Pizza>())
        {

            // Set boxed pizza
            pizzaBox.GetComponent<Pizza>().SetPizza(chefPickup.heldObject.GetComponent<Pizza>());
            pizzaBox.GetComponent<Pizza>().SetBoxed(true);

            // Destroy old pizza
            GameObject temp = chefPickup.heldObject;
            chefPickup.ClearOldPickup(chefPickup.heldObject);
            GameObject.Destroy(temp);

            chefPickup.SetNewPickup(Instantiate(pizzaBox));
        }
    }
}