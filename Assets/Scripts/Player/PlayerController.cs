using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public Rigidbody2D body;
        
        float horizontal;
        float vertical;
        float moveLimiter = 0.7f;
        private Animator anim;
        public float runSpeed = 20.0f;
        public bool flippedLeft;
        public bool facingRight;
        void Start ()
        {
            anim = GetComponent<Animator>();
            body = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Gives a value between -1 and 1
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down

            // Tính toán tốc độ lớn nhất của người chơi
            float playerSpeed = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));

            // Set animation
            anim.SetFloat("run", Mathf.Abs(horizontal));
            if (vertical != 0) // Nếu di chuyển theo chiều dọc
            {
                anim.SetFloat("run", Mathf.Abs(vertical)); // Sử dụng vertical thay cho horizontal
            }
            else // Nếu không di chuyển theo chiều dọc
            {
                anim.SetFloat("run", Mathf.Abs(horizontal)); // Giữ nguyên xử lý cho di chuyển ngang
            }
            float input=horizontal;
            //Xoay người chơi
            if(input <0)
            {
                // spriteRenderer.flipX = true;
                facingRight = false;
                Flip(false);
            }
            else if(input >0)
            {
                facingRight = true;
                Flip(true);
                // spriteRenderer.flipX = false;
            }
        }

        void FixedUpdate()
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        void Flip(bool facingRight)
        {
            if(flippedLeft && facingRight)
            {
                transform.Rotate(0, -180, 0);
                flippedLeft = false;
            }
            if(!flippedLeft && !facingRight)
            {
                transform.Rotate(0, -180, 0);
                flippedLeft = true;
            }
        }
    }
