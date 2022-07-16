using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceFood : MonoBehaviour
{
    public GameObject foodPrefab;
    private bool PrefabCreated = false;
    private string FoodName;

    // Start is called before the first frame update
    void Start()
    {
        PrefabCreated = false;
        FoodName = foodPrefab.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(FoodName)!= null)
        {

            PrefabCreated = true;

        }
        else
        {
            PrefabCreated = false;
        }
              


    }

   


}

   
