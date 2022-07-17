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
    
    [Header("Text properties")] 
    [SerializeField] private TextMeshProUGUI attributeText;
    public  TextMeshProUGUI sauceText;
    public List<TextMeshProUGUI> toppingsText;

    void Update()
    {
        if (attribute)
        {
            attribute = false;
            attributeText.fontStyle ^= FontStyles.Strikethrough;
        }

        if (sauce)
        {
            sauce = false;
            sauceText.fontStyle ^= FontStyles.Strikethrough;
        }

        for (int i = 0; i < toppings.Count; i++)
        {
            if (toppings[i])
            {
                toppings[i] = false;
                toppingsText[i].fontStyle ^= FontStyles.Strikethrough;
            }
        }
    }
    
    public void NewOrder(int _difficulty)
    {
        GameObject.FindObjectOfType<NPC_Manager>().GetComponent<NPC_Manager>().spawnNewNPC = true;
        order = orderGenerator.GenerateOrder(_difficulty);

        attributeText.fontStyle = FontStyles.Normal;
        sauceText.fontStyle = FontStyles.Normal;

        sauce = false;
        attribute = false;
        toppings = new List<bool>();
        for (int i = 0; i < Int32.Parse(order[0]); i++)
        {
            toppingsText[i].fontStyle = FontStyles.Normal;
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
