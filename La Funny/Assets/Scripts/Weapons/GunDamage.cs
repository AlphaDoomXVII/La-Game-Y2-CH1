using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GunDamage : MonoBehaviour
{
    [Header("Game Objects")]
    public Transform weapon;
    public GameObject bulletPrefab;
    private GameObject newBullet;
    public Rigidbody rb;

    [Header("Floats")]
    public float bulletSpeed;
    public float bulletLifeTime;

    public void Shoot()
    {
        newBullet = Instantiate(bulletPrefab, weapon.position + weapon.forward, Quaternion.identity) as GameObject;

        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        Destroy(newBullet, bulletLifeTime);
    }
}
