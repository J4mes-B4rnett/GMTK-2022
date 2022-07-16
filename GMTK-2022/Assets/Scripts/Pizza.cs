using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [Header("Ingredients")]
    [SerializeField] List<string> toppings = new List<string>();
    [SerializeField] string sauce = "";

    [Header("Pizza Rating")]
    [SerializeField]
    int rating = 100;
    [SerializeField]
    int cooked = 0;
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
}
