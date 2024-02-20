using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOfTeammateScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject enemy;
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public static int damage=100;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy != null)
        {
            Vector3 direction = (enemy.transform.position - transform.position).normalized;
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
