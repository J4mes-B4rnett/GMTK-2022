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
    [SerializeField] int pizzaToppingPenalty = 8;
    [SerializeField] int pizzaSaucePenalty = 10;
    [SerializeField] int pizzaBoxPenalty = 50;

    public int totalSuccessfulPizzas = 0;
    public int totalPizzasCompleted = 0;
    public int totalRentPayed = 0;
    public int totalDays = 0;
    public int finalDifficulty = 0;

    [SerializeField] float interactionDistance = 1f;

    [SerializeField] private TextMeshProUGUI textTP;
    [SerializeField] private TextMeshProUGUI textSP;
    [SerializeField] private TextMeshProUGUI textIP;
    [SerializeField] private TextMeshProUGUI textTR;
    [SerializeField] private TextMeshProUGUI textTD;
    [SerializeField] private TextMeshProUGUI textFD;

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
        textTP.text = totalPizzasCompleted.ToString();
        textSP.text = totalSuccessfulPizzas.ToString();
        textIP.text = (totalPizzasCompleted - totalSuccessfulPizzas).ToString();
        textTR.text = totalRentPayed.ToString();
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
