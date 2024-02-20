using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateControllerVer2 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject[] enemies; // Lưu trữ danh sách kẻ địch
    public float moveSpeed = 4.5f;
    public float minDistance = 2.0f;

    private bool isFacingRight = true;
    private Vector3 originalScale;
    private bool isMoving = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        FindEnemies(); // Tìm kẻ địch mỗi frame
        MoveTowardsTarget();
    }

    void FindEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void MoveTowardsTarget()
    {
        if (enemies.Length > 0)
        {
            GameObject nearestEnemy = GetNearestEnemy();
            MoveTowards(nearestEnemy.transform.position);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                MoveTowards(player.transform.position);
            }
        }
    }

    GameObject GetNearestEnemy()
    {
        GameObject nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;

        if (direction.magnitude > minDistance)
        {
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            Flip(direction.x);
            SetRunAnimation(true);
        }
        else
        {
            SetRunAnimation(false);
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

    void SetRunAnimation(bool isRunning)
    {
        if (anim != null)
        {
            anim.SetBool("Run", isRunning);
        }
    }
}
