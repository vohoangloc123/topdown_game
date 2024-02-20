// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeaponParent : MonoBehaviour
// {
//     public SpriteRenderer characterRenderer, weaponRenderer;
//     public Vector2 PointerPosition{get; set;}
//     public Animator animator;
//     public float delay=0.3f;
//     private bool attackBlocked;
//     // Start is called before the first frame update
//     void Start()
//     {
//         Vector2 direction= (PointerPosition-(Vector2)transform.position).normalized;
//         transform.right=direction;
//         Vector2 scale=transform.localScale;
//         if(direction.x <0)
//         {
//             scale.y=-1;
//         }
//         transform.localScale=scale;
//         if(transform.eulerAngles.z>0 && transform.eulerAngles.z<180)
//         {
//             weaponRenderer.sortingOrder=characterRenderer.sortingOrder-1;
//         }else
//         {
//             weaponRenderer.sortingOrder=characterRenderer.sortingOrder+1;
//         }
//     }

//     public void Attack()
//     {   
//         if(attackBlocked)
//             return;
//         animator.SetTrigger("Attack");
//         attackBlocked=true;
//         StartCoroutine(DelayAttack());

//     }
//     private IEnumerator DelayAttack()
//     {
//         yield return new WaitForSeconds(delay);
//         attackBlocked=false;
//     }
//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f; // Khoảng cách để tấn công
    public string targetTag = "Enemy"; // Tag của đối tượng cần tấn công
    public Animator animator; // Animator của enemy

    void Update()
    {
        // Nếu người chơi nhấp chuột phải, thực hiện tấn công
        if (Input.GetMouseButtonDown(1))
        {
            Attack(); // Gọi hàm tấn công
        }
    }

    void Attack()
    {
        // Tìm đối tượng gần nhất có tag là "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        // Nếu có đối tượng gần đủ để tấn công
        if (nearestEnemy != null && nearestDistance <= attackRange)
        {
            // Chạy trigger "Attack" trong Animator
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
            // Viết code tấn công ở đây, ví dụ: gọi hàm tấn công của enemy
            // Có thể sử dụng RaycastHit để xác định xem enemy có thể tấn công được hay không
        }
    }
}
