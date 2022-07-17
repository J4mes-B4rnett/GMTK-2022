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

    void Start()
    {
        IncrementDay();
    }
    
    void Update()
    {
        if (rentPayed > rentCost)
        {
            IncrementDay();
        }
    }
    
    void IncrementDay()
    {
        GameObject.FindObjectOfType<Order_Handling>().GetComponent<Order_Handling>().NewOrder(difficulty);
        day += 1;
        rentCost = 100 + (day * 25);
        if (day % 2 == 0 && difficulty < 4) // If this is an even day and the difficulty is less than 4, increase the number of ingredients
        {
            difficulty += 1;
        }

        GetComponent<TextMeshProUGUI>().text = "Day " + day.ToString();
    }
}
