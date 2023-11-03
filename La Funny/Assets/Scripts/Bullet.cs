using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Properties")]
    public float damage;
    public Collider Collider;

    void Start()
    {
        Collider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);

        if (collision.gameObject.TryGetComponent<NPCManager>(out NPCManager enemy))
        {
            enemy.health -= damage;

            Debug.Log("Enemy is hit by bullet");
        }
        
        Destroy(gameObject);
    }
}
