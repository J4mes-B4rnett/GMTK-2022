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
                string fileName = @"Assets/Scripts/Ingredients/toppings.txt";
                IEnumerable<string> lines = File.ReadLines(fileName);
                Console.WriteLine(String.Join(Environment.NewLine, lines));
                return lines.ElementAt((int)Random.Range(0, lines.Count()));
            }
            case 2:
            {
                string fileName = @"Assets/Scripts/Ingredients/sauces.txt";
                IEnumerable<string> lines = File.ReadLines(fileName);
                Console.WriteLine(String.Join(Environment.NewLine, lines));
                return lines.ElementAt((int)Random.Range(0, lines.Count()));
            }
            case 3:
            {
                string fileName = @"Assets/Scripts/Ingredients/attributes.txt";
                IEnumerable<string> lines = File.ReadLines(fileName);
                return lines.ElementAt((int)Random.Range(0, lines.Count()));
            }
            default: // Just in case you forget to add something here
                return "hey_you_made_an_error";
        }
    }
    
    public List<string> GenerateOrder(int ingredientCount)
    {
        List<string> ingredients;
        ingredients = new List<String>();
        ingredients.Add((ingredientCount).ToString());
        var newIngredient = "";
        
        if (ingredientCount > 1) // When there are multiple ingredients
        {
            for (var i = 0; i < ingredientCount; i++)
            {
                newIngredient = RandomIngredient(1);
                ingredients.Add(newIngredient);
            }
        }
        else
        {
            newIngredient = RandomIngredient(1);
            ingredients.Add(newIngredient);
        }
        
        newIngredient = RandomIngredient(2);
        ingredients.Add(newIngredient);
        
        newIngredient = RandomIngredient(3);
        ingredients.Add(newIngredient); ;
        return ingredients;
    }

    public string OrderString(List<string> ingredients)
    {
        string order = "Hello, I would like ";
        if (Int32.Parse(ingredients[0]) > 1)
        {
            for (var i = 0; i < Int32.Parse(ingredients[0]); i++)
            {
                order += ingredients[i + 1] + ", ";
            }
        }
        else
        {
            order += ingredients[1];
        }

        order += "& ";
        order += ingredients[Int32.Parse(ingredients[0]) + 1];
        order += " - and please ";
        order += ingredients[Int32.Parse(ingredients[0]) + 2];
        order += "!";
        return order;
    }
}
