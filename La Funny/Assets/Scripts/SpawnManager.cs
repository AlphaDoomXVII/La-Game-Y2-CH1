using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
