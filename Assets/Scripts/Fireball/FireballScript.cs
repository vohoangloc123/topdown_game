using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
     public int damage=100;
      private GameObject enemy;
      
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
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
            // Sau khi xử lý va chạm với Enemy, hủy viên đạn;
        }
    }
}
