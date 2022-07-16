using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpV2 : MonoBehaviour
{

    public Transform HoldPoint;
    [SerializeField] private Transform PlayerTransform;
    private float ImpactRadius = 7f;
    private GameObject Object;
    public bool ObjectDetected = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectDetected == true)
        {
            Object.transform.parent = PlayerTransform;
            Object.transform.position = HoldPoint.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Object = collision.gameObject;
        ObjectDetected = true;
    }

}
