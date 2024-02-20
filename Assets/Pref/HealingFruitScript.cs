using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFruitScript : MonoBehaviour
{
    public int heal = -50; 
    private bool collected = false;
    public AudioClip fruitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected) // Kiểm tra nếu player va chạm với fruit và chưa nhặt lần nào
        {
            collected = true;
            AudioSource.PlayClipAtPoint(fruitSound, transform.position); // Phát âm thanh tại vị trí hiện tại

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
            {
                int healAmount = 400;
                int remainingSpace = playerHealth.maxHealth - playerHealth.health;
                healAmount = Mathf.Min(healAmount, remainingSpace); // Giới hạn hồi máu không vượt quá khoảng trống còn lại

                playerHealth.Heal(healAmount);
            }

            // Biến mất fruit
            Destroy(gameObject);
        }
    }
}
