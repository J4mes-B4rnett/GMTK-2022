using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                Debug.Log("You have added " + ingredient.gameObject.name + " to your pizza!");
            this.toppings.Add(ingredient.gameObject.name.Substring(0, ingredient.gameObject.name.IndexOf('(')));
            GameObject.Destroy(ingredient.gameObject);
        }
    }
}
