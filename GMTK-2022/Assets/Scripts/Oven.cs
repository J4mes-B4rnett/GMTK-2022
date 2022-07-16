using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    Pizza pizza;
    bool isFullyCooked = false;

    private AudioSource alert;

    void Start()
    {
        alert = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (pizza)
        {
            pizza.cooked = 1 * Time.deltaTime;

            if(pizza.cooked <= 100)
            {
                alert.Play();
                // Make noise, flash oven, alert player somehow
            }
        }
    }
}
