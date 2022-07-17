using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpV2 : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] public bool isDebugging;
    [SerializeField] public bool isDebuggingTime;

    [Header("Pickup Options")]
    public Transform HoldPoint;
    [SerializeField] private Transform PlayerTransform;
    public GameObject heldObject;
    public bool ObjectDetected = false;
    public bool isHoldingObject = false;
    private float pickupTimer = 0;
    [SerializeField] public float pickupTimelimit = 1;
    SpriteRenderer heldObjectSprite;
    [SerializeField] public float dropDistance = 1;

    private bool inTrigger = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ObjectDetected && !isHoldingObject)
        {
            isHoldingObject = true;
            heldObjectSprite = heldObject.gameObject.GetComponent<SpriteRenderer>();
            heldObjectSprite.sortingOrder = 3;
            pickupTimer = 0;

            if (isDebugging)
                Debug.Log("Picking up " + heldObject.name);
        }
        
        if(isHoldingObject && heldObject)
        {
            if(Input.GetKeyDown(KeyCode.Space) && pickupTimer >= pickupTimelimit)
            {
                ClearOldPickup(heldObject);
            }
            else
            {
                if(isDebugging && isDebuggingTime)
                    Debug.Log("Held item is " + heldObject.name + pickupTimer);
        
                heldObject.transform.parent = PlayerTransform;
                heldObject.transform.position = HoldPoint.position;
            }
        }

        pickupTimer += 1 * Time.deltaTime;

        if (isDebugging)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D) && !isDebuggingTime)
            {
                isDebuggingTime = true;
            }
            else if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D) && isDebuggingTime)
            {
                isDebuggingTime = true;
            }
            
            if (isDebuggingTime)
            {
                Debug.Log("Pickup Timer at " + pickupTimer);
            }
        }

    }

    public void SetNewPickup(GameObject myObject)
    {
        heldObject = myObject;
        ObjectDetected = true;
        isHoldingObject = true;
        heldObjectSprite = heldObject.gameObject.GetComponent<SpriteRenderer>();
        heldObjectSprite.sortingOrder = 3;
        pickupTimer = 0;
    }

    public void ClearOldPickup(GameObject myObject)
    {
        if (isDebugging)
            Debug.Log("Dropping " + heldObject.name);

        heldObjectSprite.sortingOrder = 1;
        isHoldingObject = false;
        ObjectDetected = false;
        pickupTimer = 0;
        heldObject.transform.parent = null;
        heldObject.transform.position = this.transform.position + (Vector3.down * dropDistance);
        heldObject = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if ((collision.gameObject.CompareTag("Collectible") || collision.gameObject.CompareTag("Topping")) && pickupTimer >= pickupTimelimit) 
            {
                heldObject = collision.gameObject; 
                ObjectDetected = true;
            }
        }
    }
}
