using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    public float moveSpeed = 5.0f; // Tốc độ di chuyển của Enemy

    private bool isFacingRight = true;
    private float left_right;
    private Vector3 originalScale; // Lưu kích thước ban đầu

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();

        // Lưu kích thước ban đầu của Enemy
        originalScale = transform.localScale;
    }

    void Update()
{
    if (player != null)
    {
        // Tính vector hướng từ Enemy tới Player
        Vector3 direction = player.transform.position - transform.position;

        // Chuẩn hóa vector hướng nếu cần
        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }



        // Di chuyển Enemy theo hướng Player
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        left_right = direction.x;
        Flip();
    }
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
