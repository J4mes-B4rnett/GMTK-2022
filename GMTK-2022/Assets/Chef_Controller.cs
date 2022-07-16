using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef_Controller : MonoBehaviour
{
    public Animator animController;

    void Awake()
    {
        animController = GetComponent<Animator>();
    }
    
    void Update()
    {
        float modifier = Time.deltaTime;
        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector2(0f, 4f * modifier));
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector2(-4f * modifier, 0f));
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector2(0f, -4f * modifier));
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector2(4f * modifier, 0f));
        }
    }
}
