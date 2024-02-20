using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player; // Thêm biến để lưu trữ đối tượng player
    private GameObject enemy;
    public float moveSpeed = 5.0f; // Tốc độ di chuyển của Enemy

    private bool isFacingRight = true;
    private float left_right;
    private Vector3 originalScale; // Lưu kích thước ban đầu
    private GameObject[] enemies; // Mảng các đối tượng enemy

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Tìm đối tượng Player
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();

        // Lưu kích thước ban đầu của Enemy
        originalScale = transform.localScale;
    }

    void Update()
    {
        // if (enemy != null)
        // {
        //     EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        //     if (enemyHealth != null)
        //     {
        //         float healthPercentage = (float)enemyHealth.health / enemyHealth.maxHealth;
        //         if (healthPercentage < 0.6f) // Kiểm tra nếu máu hiện tại là dưới 60% của máu tối đa
        //         {
        //             MoveTowardsObject(enemy); // Di chuyển theo Enemy
        //             Debug.Log("Duy chuyển theo enemy");
        //         }
        //         else
        //         {
        //             MoveTowardsObject(player); // Di chuyển theo Player
        //             Debug.Log("Duy chuyển theo người chơi");
        //         }
        //     }
        // }
         enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Tìm tất cả các đối tượng Enemy còn sống
        if (enemies.Length > 0)
        {
            EnemyHealth enemyHealth = enemies[0].GetComponent<EnemyHealth>(); // Chỉ lấy một enemy đầu tiên để kiểm tra máu
            if (enemyHealth != null)
            {
                float healthPercentage = (float)enemyHealth.health / enemyHealth.maxHealth;
                if (healthPercentage < 0.6f&&enemy.layer != LayerMask.NameToLayer("Healer")) // Kiểm tra nếu máu hiện tại là dưới 60% của máu tối đa
                {
                    MoveTowardsObject(enemies[0]); // Di chuyển theo Enemy đầu tiên
                    Debug.Log("Duy chuyển theo enemy");
                }
                else
                {
                    MoveTowardsObject(player); // Di chuyển theo Player
                    Debug.Log("Duy chuyển theo người chơi");
                }
            }
        }
        else
        {
            MoveTowardsObject(player); // Nếu không còn enemy nào, di chuyển theo Player
            Debug.Log("Không còn enemy, di chuyển theo người chơi");
        }
    }

    // void MoveTowardsObject(GameObject target)
    // {
    //     // Tính vector hướng từ Enemy tới target (Player hoặc Enemy)
    //     Vector3 direction = target.transform.position - transform.position;

    //     // Chuẩn hóa vector hướng nếu cần
    //     if (direction.magnitude > 1)
    //     {
    //         direction.Normalize();
    //     }

    //     // Di chuyển Enemy theo hướng target (Player hoặc Enemy)
    //     transform.Translate(direction * moveSpeed * Time.deltaTime);

    //     left_right = direction.x;
    //     Flip();
    // }
    void MoveTowardsObject(GameObject target)
    {
        // Tính vector hướng từ Enemy tới target (Player hoặc Enemy)
        Vector3 direction = target.transform.position - transform.position;

        // Kiểm tra nếu di chuyển theo enemy, và khoảng cách nhỏ hơn 2f, thì không di chuyển
        if (target.CompareTag("Enemy") && direction.magnitude < 2f)
        {
            return;
        }

        // Chuẩn hóa vector hướng nếu cần
        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        // Di chuyển Enemy theo hướng target (Player hoặc Enemy)
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        left_right = direction.x;
        Flip();
    }


    void Flip()
    {
        if ((isFacingRight && left_right < 0) || (!isFacingRight && left_right > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 kichThuoc = transform.localScale;
            kichThuoc.x = kichThuoc.x * -1;
            transform.localScale = kichThuoc;
        }
    }

    public void PauseMovement(bool pause)
    {
        // Tắt hoặc bật component EnemyMovement tùy thuộc vào tham số pause
        this.enabled = !pause;
    }
}
