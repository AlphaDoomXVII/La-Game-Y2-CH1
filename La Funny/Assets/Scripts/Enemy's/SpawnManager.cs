using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour   //laat je code toevoegen aan het game object " SpawnManager "
{
    public GameObject enemyPrefab;      //Welke object word er gespawnt wanneer het script getriggerd word
    public Transform spawnPoint;        //laat het object weten dat het op het "spawnpoint" moet spawnen

    void Update()   //kijkt of er code door komt (maar er komt niks door)
    {
        if (Input.GetKeyDown(KeyCode.F)) //De action key om het script te triggeren
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent); //wanneer de F key gebruikt word, word  de enemy object op zijn parent (spawnpoint) gespawnt.
        }
    }
}
