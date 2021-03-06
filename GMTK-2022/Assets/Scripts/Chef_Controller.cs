using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef_Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Animator _animController;
    private PickUpV2 pickUp;


    private Vector2 movement;

    void Awake()
    {
        _animController = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        pickUp = gameObject.GetComponent<PickUpV2>();
        //pickUp.HoldDirection = new Vector2(0, 0);
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > 0.1f)
        {
            //pickUp.HoldDirection = movement.normalized;
        }
        
        _animController.SetFloat("Horizontal", movement.x);
        _animController.SetFloat("Vertical", movement.y);
        _animController.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * (moveSpeed * Time.deltaTime));
    }
}
