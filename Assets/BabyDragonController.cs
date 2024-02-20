using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDragonController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    public float moveSpeed = 4.5f; // Tốc độ di chuyển của Enemy
    public float minDistance = 2.0f; // Khoảng cách tối thiểu giữa BabyDragon và người chơi

    private bool isFacingRight = true;
    private Vector3 originalScale; // Lưu kích thước ban đầu

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;

            // Kiểm tra nếu khoảng cách lớn hơn khoảng cách tối thiểu
            if (direction.magnitude > minDistance)
            {
                direction.Normalize();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
                Flip(direction.x);
            }
        }
    }

    void Flip(float directionX)
    {
        if ((isFacingRight && directionX < 0) || (!isFacingRight && directionX > 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
