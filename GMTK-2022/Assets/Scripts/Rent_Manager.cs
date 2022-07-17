using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rent_Manager : MonoBehaviour
{
    public int day = 0;
    public int difficulty = 1;

    public int rentCost = 100;
    public int rentPayed = 0;

    [SerializeField] private TextMeshProUGUI dayString;

    void Start()
    {
        NextPizza();
        IncrementDay();
    }
    
    void Update()
    {
        if (rentPayed > rentCost)
        {
            IncrementDay();
        }

        GetComponent<TextMeshProUGUI>().text = "£" + (rentCost - rentPayed).ToString() + " rent due";
    }

    public void NextPizza()
    {
        GameObject.FindObjectOfType<Order_Handling>().GetComponent<Order_Handling>().NewOrder(difficulty);    
    }
    
    void IncrementDay()
    {
        day += 1;
        rentPayed = 0;
        rentCost = 100 + (day * 25);
        if (day % 2 == 0 && difficulty < 4) // If this is an even day and the difficulty is less than 4, increase the number of ingredients
        {
            difficulty += 1;
        }

        dayString.text = "Day " + day.ToString();
    }
}
