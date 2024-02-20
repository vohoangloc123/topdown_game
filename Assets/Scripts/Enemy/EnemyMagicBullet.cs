using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * force;

            float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }
        else
        {
            // Nếu không tìm thấy đối tượng kẻ địch, di chuyển theo hướng ngẫu nhiên
            float randomAngle = Random.Range(0f, 360f); // Chọn một góc ngẫu nhiên trong khoảng 0-360 độ
            Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
            rb.velocity = randomDirection.normalized * force;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
