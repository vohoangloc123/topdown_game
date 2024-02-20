using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal : MonoBehaviour
{
    public int damage=-100;
    private EnemyHealth EnemyHealth;

    private void Start()
    {
        EnemyHealth = FindObjectOfType<EnemyHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            EnemyHealth.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
