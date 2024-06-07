
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Tag của đối tượng Enemy
    public Animator animator; // Animator của đối tượng Player
    public static int damage = 100;
    public float attackRange = 2f; // Phạm vi tấn công

    private GameObject nearestEnemy; // Lưu trữ đối tượng Enemy gần nhất

    void Update()
    {
        FindNearestEnemy(); // Tìm kẻ địch gần nhất mỗi frame
        if (nearestEnemy != null)
        {
            float distance = Vector3.Distance(transform.position, nearestEnemy.transform.position);
            if (distance <= attackRange)
            {
                // Nếu ở gần địch, thực hiện tấn công
                Attack();
            }
        }
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // Tìm tất cả các đối tượng có tag là Enemy
        nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Tìm kẻ địch gần nhất
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy;
            }
        }
    }

    void Attack()
    {
        // Thực hiện hành động tấn công

        // Kích hoạt Animator để thực hiện Animation Attack
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Gọi hàm tấn công của EnemyHealth (đặt tên hàm TakeDamage hoặc tương tự)
        // EnemyHealth enemyHealth = nearestEnemy.GetComponent<EnemyHealth>();
        // if (enemyHealth != null)
        // {
        //     enemyHealth.TakeDamage(damage);
        // }
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
