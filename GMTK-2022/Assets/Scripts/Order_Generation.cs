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
                List<string> lines = new List<string>();
                lines.Add("pepperonis");
                lines.Add("cheddar");
                lines.Add("parmesan");
                lines.Add("mushrooms");
                lines.Add("ham");
                lines.Add("anchovies");
                lines.Add("bell pepper");
                lines.Add("garlic");
                lines.Add("pineapple");
                lines.Add("sweetcorn");
                lines.Add("black olives");
                lines.Add("bananas");
                return lines[Random.Range(0, lines.Count())];
            }
            case 2:
            {
                List<string> lines = new List<string>();
                lines.Add("tomato sauce");
                lines.Add("alfredo sauce");
                lines.Add("bbq sauce");
                lines.Add("peanut butter");
                lines.Add("hot sauce");
                return lines[Random.Range(0, lines.Count())];
            }
            case 3:
            {
                List<string> lines = new List<string>();
                lines.Add("make it extra fast");
                lines.Add("cook it extra hot");
                lines.Add("cook it extra cool");
                return lines[Random.Range(0, lines.Count())];
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
