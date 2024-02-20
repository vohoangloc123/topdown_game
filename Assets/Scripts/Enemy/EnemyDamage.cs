using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    public int damage;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

