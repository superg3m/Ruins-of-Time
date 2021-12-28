using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject fireballPrefab;

    public float fireball_speed = 20f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }


    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireball_speed, ForceMode2D.Impulse);
        // Acts like a range constraint for projectiles
        Destroy(fireball, 2f);
    }
}
