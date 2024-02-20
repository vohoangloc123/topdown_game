using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    public float moveSpeed = 4.5f;
    public float minDistance = 2.0f;

    private bool isFacingRight = true;
    private Vector3 originalScale;
    private bool isMoving = false; // Thêm biến để theo dõi trạng thái di chuyển

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

            if (direction.magnitude > minDistance)
            {
                direction.Normalize();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
                Flip(direction.x);
                SetRunAnimation(true); // Set animation chạy khi di chuyển
            }
            else
            {
                SetRunAnimation(false); // Set animation đứng yên khi không di chuyển
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

    // Hàm để cập nhật giá trị của biến 'Run' trong Animator
    void SetRunAnimation(bool isRunning)
    {
        if (anim != null)
        {
            anim.SetBool("Run", isRunning);
        }
    }
}
