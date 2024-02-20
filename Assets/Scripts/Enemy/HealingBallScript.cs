
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public int damage;
    public ParticleSystem healthEffect;
    public GameObject currentBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindAndShootEnemy();
    }

    void FindAndShootEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        bool shouldDestroy = true;

        foreach (GameObject enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null&&enemy.layer != LayerMask.NameToLayer("Healer"))
            {
                float healthPercentage = (float)enemyHealth.health / enemyHealth.maxHealth;

                if (healthPercentage < 0.6f)
                {
                    Vector3 direction = (enemy.transform.position - transform.position).normalized;
                    rb.velocity = direction * force;

                    float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, rot);

                    shouldDestroy = false; // Nếu có kẻ địch có máu dưới 60%, không hủy đối tượng
                    break;
                }
            }
        }

        if (shouldDestroy)
        {
            Destroy(gameObject); // Hủy đối tượng nếu không còn kẻ địch hoặc tất cả đều có máu >= 60%
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                ParticleSystem health = Instantiate(healthEffect, currentBullet.transform.position, Quaternion.identity);
                health.Play();
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
