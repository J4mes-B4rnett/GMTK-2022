using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private float playerSpeed;
    PickUpV2 chefPickup;
    [SerializeField]
    bool isDebugging = false;
    [SerializeField] float interactionDistance = .4f;

    [SerializeField]
    GameObject fridge;

    [SerializeField]
    List<Transform> sauceSlots;

    private List<GameObject> sauceObjects = new List<GameObject>();
    private bool sauceInitiated = false;

    [SerializeField]
    List<GameObject> sauces;
    // Start is called before the first frame update
    void Start()
    {
        chefPickup = player.GetComponent<PickUpV2>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player distance
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if (playerDistance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && !chefPickup.heldObject)
        {
            if(isDebugging)
            {
                Debug.Log("Fridge UI is open.");
            }
            // TODO will probably make the fridge stop working since script will be deactivated too
            fridge.SetActive(true);
            playerSpeed = player.GetComponent<Chef_Controller>().moveSpeed;
            player.GetComponent<Chef_Controller>().moveSpeed = 0;
            SetSauces();


        }

        if (Input.GetKeyDown(KeyCode.Escape) && sauceInitiated)
        {
            fridge.SetActive(false);
            player.GetComponent<Chef_Controller>().moveSpeed = playerSpeed;
            foreach (GameObject sauce in sauceObjects)
            {
                if (isDebugging)
                    Debug.Log(sauce.name + " destroyed!");
                GameObject.Destroy(sauce);
            }
            sauceInitiated = false;

        }

    }

    private void SetSauces()
    {
        List<GameObject> tempSauces = new List<GameObject>();
        sauceObjects = new List<GameObject>();
        tempSauces.AddRange(sauces);
        sauceInitiated = true;

        foreach (Transform slot in sauceSlots)
        {
            
            int sauceIndex = Random.Range(0, tempSauces.Count);

            if (isDebugging)
            {
                Debug.Log("tempSauces Size: " + tempSauces.Count);
            }
                
            GameObject sauce = Instantiate(tempSauces[sauceIndex]);

            if(isDebugging)
            Debug.Log(sauce.name + " created!");

            sauceObjects.Add(sauce);
            sauce.transform.position = slot.position;
            sauce.gameObject.transform.parent = slot;
            tempSauces.RemoveAt(sauceIndex);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, interactionDistance);
    }
}
