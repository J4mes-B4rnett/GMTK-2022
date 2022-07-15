using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class Order_Generation : MonoBehaviour
{
    string RandomIngredient(int type)
    {
        switch (type)
        {
            case 1:
            {
                string fileName = @"Assets/Scripts/toppings.txt";
                IEnumerable<string> lines = File.ReadLines(fileName);
                Console.WriteLine(String.Join(Environment.NewLine, lines));
                return lines.ElementAt((int)Random.Range(0, lines.Count()));
            }
            case 2:
            {
                string fileName = @"Assets/Scripts/sauces.txt";
                IEnumerable<string> lines = File.ReadLines(fileName);
                Console.WriteLine(String.Join(Environment.NewLine, lines));
                return lines.ElementAt((int)Random.Range(0, lines.Count()));
            }
            case 3:
            {
                string fileName = @"Assets/Scripts/attributes.txt";
                IEnumerable<string> lines = File.ReadLines(fileName);
                return lines.ElementAt((int)Random.Range(0, lines.Count()));
            }
            default: // Just in case you forget to add something here
                return "hey_you_made_an_error";
        }
    }
    
    string OrderGenerator(int ingredientCount)
    {
        string orderString = "I would like a pizza with ";
        if (ingredientCount > 1) // When there are multiple ingredients
        {
            for (var i = 0; i < ingredientCount; i++)
            {
                
            }
        }
        else
        {
            orderString += RandomIngredient(1);
        }
        
        orderString += ", I also want ";
        orderString += RandomIngredient(2);
        orderString += ", and please ";
        orderString += RandomIngredient(3);
        orderString += "!";
        return orderString;
    }

    public void Start()
    {
        print(OrderGenerator(1));
    }
}
