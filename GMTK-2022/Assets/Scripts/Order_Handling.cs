using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Order_Handling : MonoBehaviour
{
    public List<string> order;
    public Order_Generation orderGenerator;

    [Header("Pizza requirements for completion")]
    public List<bool> toppings;
    public bool sauce;
    public bool attribute;
    
    private int _difficulty = 3;

    void Start()
    {
        NewOrder();
    }
    
    void NewOrder()
    {
        order = orderGenerator.GenerateOrder(_difficulty);

        sauce = false;
        attribute = false;
        toppings = new List<bool>();
        for (int i = 0; i < Int32.Parse(order[0]); i++)
        {
            toppings.Add(false);
        }
    }
}
