using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pizza : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] bool isDebugging = false;

    [Header("Ingredients")]
    [SerializeField] public List<string> toppings = new List<string>();
    [SerializeField] public string sauce = "";

    [Header("Pizza Rating")]
    [SerializeField]
    public float rating = 100;
    [SerializeField]
    public float cooked = 0;
    public bool doneCooking = false;
    public bool isBoxed = false;

    private Order_Handling _orderHandler;
    
    void Start()
    {
        _orderHandler = GameObject.FindObjectOfType<Order_Handling>().GetComponent<Order_Handling>();
    }

    void Update()
    {
        // If gameobject is ingredient and ingredient is prepped, add to pizza.

        // order handling should handle rating system?

        // Oven should updated cooked property. If it goes over, start subtracting score.
    }

    public void AddIngredient(GameObject ingredient)
    {
        if(ingredient.CompareTag("Topping"))
        {
            if (isDebugging)
                print("You have added " + ingredient.gameObject.name + " to your pizza!");
            for (int i = 0; i < (_orderHandler.toppings.Count); i++)
            {
                print("Ingredient 1: " + ingredient.gameObject.name);
                print("Ingredient 2: " + _orderHandler.toppingsText[i].text);
                if ((ingredient.gameObject.name).Remove(ingredient.gameObject.name.Length - 7).ToLower() == _orderHandler.toppingsText[i].text.ToLower())
                {
                    _orderHandler.toppings[i] = true;
                    print("Set topping to true");
                }
            }

            if (ingredient.gameObject.name.Remove(ingredient.gameObject.name.Length - 7) == _orderHandler.sauceText.text.ToLower())
            {
                _orderHandler.sauce = true;
            }
            this.toppings.Add(ingredient.gameObject.name.Substring(0, ingredient.gameObject.name.IndexOf('(')));
            GameObject.Destroy(ingredient.gameObject);
        }
    }

    public void SetPizza(Pizza pizza)
    {
        this.Equals(pizza);
    }

    public void SetBoxed(bool passedBool)
    {
        this.isBoxed = passedBool;
    }
}
