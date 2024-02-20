using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject player;
    public float moveSpeed = 5.0f; // Tốc độ di chuyển của Enemy

    private bool isFacingRight = true;
    private Vector3 originalScale; // Lưu kích thước ban đầu
    private bool isDashing = false;
    private bool canDash = true; // Cờ để kiểm tra xem có thể dash hay không

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();

        // Lưu kích thước ban đầu của Enemy
        originalScale = transform.localScale;

        StartCoroutine(DashRepeatedly(10f));
    }

    void Update()
    {
        if (player != null && !isDashing)
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

            // Gọi hàm Dash khi cần
            if (Vector3.Distance(transform.position, player.transform.position) <= 2.0f && canDash)
            {
                StartCoroutine(PerformDash(direction));
            }
            Flip();
        }
    }

    void Flip()
    {
        // Xác định hướng của Enemy dựa trên hướng di chuyển của người chơi
        float playerDirection = player.transform.position.x - transform.position.x;

        if ((isFacingRight && playerDirection < 0) || (!isFacingRight && playerDirection > 0))
        {
            isFacingRight = !isFacingRight;

            // Flip Enemy theo hướng người chơi
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void PauseMovement(bool pause)
    {
        // Tắt hoặc bật component EnemyMovement tùy thuộc vào tham số pause
        this.enabled = !pause;
    }

    IEnumerator DashRepeatedly(float dashInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(dashInterval);

            // Kiểm tra xem có thể dash mới hay không
            if (canDash && player != null && !isDashing)
            {
                Vector3 direction = player.transform.position - transform.position;
                StartCoroutine(PerformDash(direction));
            }
        }
    }

    IEnumerator PerformDash(Vector3 dashDirection)
    {
        // Thiết lập biến isDashing thành true để đánh dấu rằng Enemy đang thực hiện dash
        isDashing = true;
        canDash = false; // Ngăn chặn Enemy từ việc dash liên tục

        // Tốc độ dash của Enemy
        float dashSpeed = 10.0f;

        // Thời gian thực hiện dash
        float dashDuration = 0.25f; // Đây là ví dụ, bạn có thể điều chỉnh thời gian dựa trên nhu cầu của bạn

        // Lưu vị trí ban đầu của Enemy trước khi dash
        Vector3 startPosition = transform.position;

        // Tính toán vị trí kết thúc của dash dựa trên hướng dash và khoảng cách cần di chuyển
        Vector3 endPosition = startPosition + dashDirection.normalized * dashSpeed * dashDuration;

        // Di chuyển Enemy theo hướng dash trong khoảng thời gian nhất định
        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Kết thúc dash, đặt lại vị trí của Enemy và thiết lập lại biến isDashing
        transform.position = endPosition;
        isDashing = false;
        
        // Đặt lại cờ cho phép dash sau khi kết thúc dash
        yield return new WaitForSeconds(5f); // Thời gian chờ trước khi có thể dash lại
        canDash = true;
    }
}
