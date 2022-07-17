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
    GameObject selector;

    [SerializeField]
    List<GameObject> sauceSlots;

    [SerializeField]
    List<GameObject> saucePrefabs;

    int sauceIndex = 0;

    private List<GameObject> sauceObjects = new List<GameObject>();
    private bool sauceInitiated = false;

    [SerializeField]
    List<GameObject> sauces;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        chefPickup = player.GetComponent<PickUpV2>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        // Get player distance
        float playerDistance = (player.transform.position - this.transform.position).magnitude;

        if (playerDistance <= interactionDistance && Input.GetKeyDown(KeyCode.E) && !chefPickup.heldObject && !fridge.active)
        {
            if(isDebugging)
            {
                Debug.Log("Fridge UI is open.");
            }
            // TODO will probably make the fridge stop working since script will be deactivated too
            fridge.SetActive(true);
            playerSpeed = player.GetComponent<Chef_Controller>().moveSpeed;
            player.GetComponent<Chef_Controller>().moveSpeed = 0;
            selector.transform.position = sauceSlots[0].transform.position;
            sauceIndex = 0;

            SetSauces();


        }

        if (Input.GetKeyDown(KeyCode.Escape) && sauceInitiated)
        {
            fridge.SetActive(false);
            player.GetComponent<Chef_Controller>().moveSpeed = playerSpeed;
            ClearSauces();
        }


        if(Input.GetKeyDown(KeyCode.D) && sauceInitiated)
        {
            // Move to next item
            sauceIndex++;
            if(sauceIndex > sauceObjects.Count - 1)
            {
                sauceIndex = 0;
            }

            selector.transform.position = sauceSlots[sauceIndex].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.A) && sauceInitiated)
        {
            // Move to previous item
            sauceIndex--;
            if (sauceIndex < 0)
            {
                sauceIndex = sauceObjects.Count - 1;
            }
            selector.transform.position = sauceSlots[sauceIndex].transform.position;

        }
        else if (Input.GetKeyDown(KeyCode.E) && timer > .5f && sauceInitiated)
        {

            string sauceName = "";
            foreach(GameObject sauce in sauceObjects)
            {
                // if sauce in slot matches sauce in sauceObject, grab sauce


                if(sauceSlots[sauceIndex].transform.GetChild(0).name == sauce.name)
                {
                    sauceName = sauce.name;
                    Debug.Log("Sauce: " + sauceName);
                    // Gimme da sauce
                }
            }

            foreach (GameObject prefab in saucePrefabs)
            {
                Debug.Log(prefab.name.Substring(0, prefab.name.IndexOf(' ')));
                Debug.Log(sauceName);
                if (sauceName.Contains(prefab.name.Substring(0, prefab.name.IndexOf(' '))))
                {
                    chefPickup.SetNewPickup(Instantiate(prefab));
                }
            }

            ClearSauces();

            fridge.SetActive(false);
            player.GetComponent<Chef_Controller>().moveSpeed = playerSpeed;
            ClearSauces();
        }


    }

    private void SetSauces()
    {
        timer = 0;
        List<GameObject> tempSauces = new List<GameObject>();
        sauceObjects = new List<GameObject>();
        tempSauces.AddRange(sauces);
        sauceInitiated = true;

        foreach (GameObject slot in sauceSlots)
        {
            
            int sauceIndex = Random.Range(0, tempSauces.Count);

            GameObject sauce = Instantiate(tempSauces[sauceIndex]);

            sauceObjects.Add(sauce);
            sauce.transform.position = slot.transform.position;
            sauce.gameObject.transform.SetParent(slot.transform);
            tempSauces.RemoveAt(sauceIndex);
        }
    }

    private void ClearSauces()
    {
        foreach (GameObject sauce in sauceObjects)
        {
            GameObject.Destroy(sauce);
        }
        sauceInitiated = false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, interactionDistance);
    }
}
