
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public HealthBar healthBar;

    public int maxHealth = 1000;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            healthBar.SetHealth(0);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            healthBar.SetHealth(health);
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    public void Heal(int amount)
    {
        health += amount;

        // Kiểm tra xem health có vượt quá maxHealth hay không
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.SetHealth(health);
    }
}
