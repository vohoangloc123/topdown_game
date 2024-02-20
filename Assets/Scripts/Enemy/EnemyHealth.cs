
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Animator animator;
    public float deathDelay = 0.5f; // Độ trễ trước khi hủy đối tượng
    private bool isDead = false;
    private EnemyController enemyMovement;
    private BossController bossMovement;
    private BoxCollider2D enemyCollider;
    [SerializeField]
    public AudioSource deadSound;
    
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the Enemy1 game object.");
        }
        enemyMovement = GetComponent<EnemyController>();
        enemyCollider = GetComponent<BoxCollider2D>(); // Gán giá trị cho enemyCollider
        bossMovement = GetComponent<BossController>();
        if (enemyCollider == null)
        {
            Debug.LogError("BoxCollider2D component is missing on the Enemy1 game object.");
        }
    }
    public void AbilityManager()
    {
        CountKillScript.killValue+=1;
        ScoreScript.scoreValue+=50;
        Experiment.expValue+=50;
        EnemySpawner.whenAllTheEnemyDefeated();
    }
    public void TakeDamage(int damage)
    {
        // Debug.Log("Enemy took " + damage + " damage.");
        
        if (animator != null)
        {
            animator.SetTrigger("Hit");
            health -= damage;
   
            if (health <= 0 && gameObject.CompareTag("Enemy"))
            {
                Die();
            }

        }
    }
  
    IEnumerator DestroyAfterDelay()
    {
        // Chờ đợi trong 0.5 giây trước khi hủy đối tượng
        yield return new WaitForSeconds(deathDelay);

        // Hủy đối tượng sau khi đã trễ
        Destroy(gameObject);
        AbilityManager();
    }
    public void Die()
    {
        isDead = true;

        // Ngừng các thành phần điều khiển di chuyển (nếu có)
        // Ví dụ: dừng các phương thức hoặc chuyển động của script di chuyển

        // Chạy animation và hủy bỏ đối tượng sau khi kết thúc animation
        if (animator != null)
        {
            // Gọi animation Dead
            animator.SetTrigger("Dead");
            // Debug.Log("Đã die");
            // Ngừng vận tốc hoặc các thành phần vật lý khác nếu có
            ControlMovementPause(true);
            //Cho box collider là isTrigger để khi quái chết thì ta không bắn trúng nó nữa
            
            
            StartCoroutine(DestroyAfterDelay());
        }
    }
    public void ControlMovementPause(bool pause)
    {
        if (enemyMovement != null)
        {
            enemyMovement.PauseMovement(pause); // Gọi phương thức PauseMovement từ EnemyMovement
        }
        if(bossMovement!=null)
        {
            bossMovement.PauseMovement(pause);
        }
        if (enemyCollider != null)
        {
            enemyCollider.enabled = !pause; // Ẩn collider
        }
 
    }
    public void PlaySound()
    {
        if(deadSound != null)
        {
            // Phát âm thanh
            deadSound.Play();
        }
        else
        {
            Debug.LogError("AudioSource reference is null!");
        }
    }
}
