using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_ImpactHandler : MonoBehaviour
{
    public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        ImpactEffect();
    }

    private void ImpactEffect()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);
        Destroy(gameObject);
    }
}
