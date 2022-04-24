using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)        // damage dealer 
    {
        health -= damage;
        if (health <=0)                 // death + VFX if health 0
        {
            Destroy(gameObject);
            TriggerDeathVFX();
        }
    }

    private void TriggerDeathVFX()          // trigger death VFX
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
