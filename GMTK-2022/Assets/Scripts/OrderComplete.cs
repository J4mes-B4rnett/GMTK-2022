using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
<<<<<<< Updated upstream
    [SerializeField] int pizzaBoxPenalty = 30;
=======
    [SerializeField] int pizzaBoxPenalty = 50;

    public int totalPizzas = 0;
    public int totalSuccessfulPizzas = 0;
    public int totalPizzasCompleted = 0;
    public int totalRentPayed = 0;
    public int totalDays = 0;
    public int finalDifficulty = 0;
>>>>>>> Stashed changes

    [SerializeField] private TextMeshProUGUI textTP;
    [SerializeField] private TextMeshProUGUI textSP;
    [SerializeField] private TextMeshProUGUI textPC;
    [SerializeField] private TextMeshProUGUI textRP;
    [SerializeField] private TextMeshProUGUI textTD;
    [SerializeField] private TextMeshProUGUI textFD;

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

        textTP.text = totalPizzas.ToString();
        textSP.text = totalSuccessfulPizzas.ToString();
        textPC.text = (totalPizzasCompleted-totalSuccessfulPizzas).ToString();
        textRP.text = "£" + totalRentPayed.ToString();
        textTD.text = totalDays.ToString();
        textFD.text = finalDifficulty.ToString();
        
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

<<<<<<< Updated upstream
            if (isDebugging)
=======

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
            
                    if (isDebugging)
>>>>>>> Stashed changes
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
