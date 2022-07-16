using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCounters : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject topCounter;
    [SerializeField]
    GameObject bottomCounter;

    SpriteRenderer bottomCounterRenderer;
    SpriteRenderer topCounterRenderer;
    // Start is called before the first frame update
    void Start()
    {
        topCounterRenderer = topCounter.GetComponent<SpriteRenderer>();
        bottomCounterRenderer = bottomCounter.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < bottomCounter.transform.position.y)
        {
            topCounterRenderer.sortingOrder = -1;
            bottomCounterRenderer.sortingOrder = 0;
        }
        else
        {
            topCounterRenderer.sortingOrder = 2;
            bottomCounterRenderer.sortingOrder = 3;
        }
    }
}
