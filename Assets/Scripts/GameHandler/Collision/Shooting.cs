using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject fireballPrefab;
    private PauseMenu pm;
    private new Rigidbody2D rigidbody2D;

    public float fireball_speed = 20f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        pm = FindObjectOfType<PauseMenu>();
        if (!pm.gameIsPaused)
        {
            if (Input.GetButtonDown("Fire1")) Shoot();
        }
        
    }


    private void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        rigidbody2D = fireball.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(firePoint.up * fireball_speed, ForceMode2D.Impulse);
        // Acts like a range constraint for projectiles
        Destroy(fireball, 0.75f);
    }
}
