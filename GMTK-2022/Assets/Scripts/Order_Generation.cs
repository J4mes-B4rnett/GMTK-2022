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
        GameObject.Find("NPCSpawner").GetComponent<NPC_Manager>().spawnNewNPC = true;
        List<string> ingredients;
        ingredients = new List<String>();
        ingredients.Add((ingredientCount).ToString());
        var newIngredient = "";
        
        if (ingredientCount > 1) // When there are multiple ingredients
        {
            int unique = 0;
            while (unique != ingredientCount)
            {
                newIngredient = RandomIngredient(1);
                int comparison = 0;
                for (int i = 0; i < ingredients.Count; i++)
                {
                    if (newIngredient == ingredients[i])
                    {
                        comparison += 1;
                    }
                }

                if (comparison == 0)
                {
                    ingredients.Add(newIngredient);
                    unique += 1;
                }
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
}
