using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTestScript : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Vector3 HoldDirection { get; set; }
    private GameObject itemHolding;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + HoldDirection;
                itemHolding.transform.parent = null;
                itemHolding = null;
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + HoldDirection, .4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                }

            }
        }

    }
}
