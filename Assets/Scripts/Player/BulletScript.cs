using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public static int damage=50;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy!=null)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot+180);
        }else{
             // Nếu không tìm thấy đối tượng kẻ địch, di chuyển theo hướng nhìn của nhân vật
            float randomAngle = Random.Range(0f, 360f); // Chọn một góc ngẫu nhiên trong khoảng 0-360 độ
            Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = randomDirection.normalized * force;
        }
    }

    void Update()
    {
            timer +=Time.deltaTime;
            if(timer>5)
            {
                Destroy(gameObject);
            }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Triggered!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Debug.Log("Da ban trung Enemy!");
                enemyHealth.TakeDamage(damage);
            }
            // Sau khi xử lý va chạm với Enemy, hủy viên đạn
            Destroy(gameObject);
        }
    }
    public static void ResetBulletScript()
    {
        damage=50;
    }

}
