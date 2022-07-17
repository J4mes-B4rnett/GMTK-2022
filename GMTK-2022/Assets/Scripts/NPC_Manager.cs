using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    [SerializeField] private Transform npcSpawnPoint;
    public bool spawnNewNPC = false;

    [SerializeField] private List<GameObject> npcs;

    private GameObject _currentNPC;
    
    void Update()
    {
        if (spawnNewNPC)
        {
            Destroy(_currentNPC);
            spawnNewNPC = false;
            _currentNPC = Instantiate(npcs[Random.Range(0, npcs.Count)], npcSpawnPoint.position, Quaternion.identity);
        }
    }
}