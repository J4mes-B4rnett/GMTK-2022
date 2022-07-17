using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rent_Manager : MonoBehaviour
{
    public int day = 1;
    public int difficulty = 1;

    public int rentCost;

    void Update()
    {
        
    }
    
    void IncrementDay()
    {
        day += 1;
        if (day % 2 == 0 && difficulty < 4) // If this is an even day and the difficulty is less than 4, increase the number of ingredients
        {
            difficulty += 1;
        }
    }
}
