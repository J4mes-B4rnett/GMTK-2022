using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Order_Handling : MonoBehaviour
{
    public List<string> order;
    public Order_Generation orderGenerator;

    [Header("Pizza requirements for completion")]
    public List<bool> toppings;
    public bool sauce;
    public bool attribute;
    
    [SerializeField] private int _difficulty;

    [Header("Text properties")] 
    [SerializeField] private TextMeshProUGUI attributeText;
    [SerializeField] private TextMeshProUGUI sauceText;
    [SerializeField] private List<TextMeshProUGUI> toppingsText;

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

        attributeText.text = order[order.Count-1];
        sauceText.text = order[order.Count - 2];
        for (int i = 1; i < order.Count - 2; i++)
        {
            toppingsText[i-1].text = order[i];
        }
    }
}
