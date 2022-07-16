using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Order_Handling : MonoBehaviour
{
    public List<string> order;
    public Order_Generation orderGenerator;

    private int _difficulty = 1;
    
    public void Update()
    {
        order = orderGenerator.GenerateOrder(_difficulty);
        
    }
}
