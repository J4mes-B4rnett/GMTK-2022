using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    Pizza pizza;
    bool isFullyCooked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pizza)
        {
            pizza.cooked = 1 * Time.deltaTime;

            if(pizza.cooked <= 100)
            {
                // Make noise, flash oven, alert player somehow
            }
        }
    }
}
