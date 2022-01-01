using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 100f;
    public float regenTime = 2.5f;
    public float regenTimer;
    public float currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        regenTimer = regenTime;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    void Update()
    {
        
        regenTimer -= Time.deltaTime;
        if(regenTimer < 0)
        {
            regenTimer = regenTime;
            currentHealth = maxHealth;
            healthBar.SetHealth(maxHealth);
        }
        if (Input.GetKeyDown(KeyCode.Space)) takeDamage(10);   
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fireball") takeDamage(10);
    }



    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
