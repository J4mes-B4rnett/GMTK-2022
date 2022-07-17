using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] bool isDebugging = false;

    [Header("Script Options")]
    GameObject player;
    GameObject playerHand;
    [SerializeField] GameObject spawnable;
    [SerializeField] float interactionDistance = .4f;


    PickUpV2 pickup;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Chef");
        playerHand = GameObject.Find("Pick Up Point");
        pickup = player.GetComponent<PickUpV2>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if (isDebugging)
            OnDrawGizmos();

        if(playerDistance <= interactionDistance)
        {
            if(Input.GetKeyDown(KeyCode.E) && !pickup.ObjectDetected)
            {
                if(isDebugging)
                Debug.Log("You have spawned a(n) " + spawnable.name);

                pickup.SetNewPickup(Instantiate(spawnable));
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, interactionDistance);
    }
}
