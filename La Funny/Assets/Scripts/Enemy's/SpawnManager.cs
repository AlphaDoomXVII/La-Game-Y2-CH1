using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
        }
    }
}
