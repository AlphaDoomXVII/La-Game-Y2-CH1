using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCooldown;

    //by default gun is semi
    public bool automatic;

    private float currentCooldown;

    void Start()
    {
        currentCooldown = fireCooldown;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && currentCooldown <= 0f)
        {
            onGunShoot?.Invoke();
            currentCooldown += fireCooldown;
        }

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
