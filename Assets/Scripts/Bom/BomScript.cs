
using System.Collections;
using UnityEngine;

public class BomScript : MonoBehaviour
{
    public ParticleSystem explosionEffect; // Hiệu ứng phát nổ
    public static float explosionRadius = 5f; // Bán kính phát nổ
    public static int damageAmount = 50; // Số máu sẽ bị trừ khi bị trúng bom
    private GameObject currentBom; // Thêm biến để lưu trữ game object của bom
    public AudioClip coinSound;
    public Animator animator;
    public BomMovement bomMovementComponent;

    private void Start()
    {
        bomMovementComponent = GetComponent<BomMovement>();
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the Enemy1 game object.");
        }
        // Gán giá trị cho currentBom bằng game object chứa script BomScript
        currentBom = gameObject;
        // Gọi Coroutine ExplodeAfterDelay với độ trễ là 3 giây
        StartCoroutine(StopTheBomAndAnimation(2f));
        StartCoroutine(ExplodeAfterDelay(3f));
    }

    private IEnumerator StopTheBomAndAnimation(float delay)
    {
        yield return new WaitForSeconds(delay); 
         if (bomMovementComponent != null)
            {
                // Tắt component BomMovement trước khi bom nổ
                bomMovementComponent.enabled = false;
                animator.SetTrigger("Explode");
                Debug.Log("Đã dừng");
            }
    }
    // Coroutine để phát nổ sau một khoảng thời gian
    private IEnumerator ExplodeAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay); // Chờ delay giây trừ đi 1 giây

        // Kiểm tra xem object bom có tồn tại không trước khi phá hủy
        if (currentBom != null)
        {
           

            // Set trigger "Explode" trên animator
            

            GameObject audioSourceTemp = new GameObject("TempAudio");
            AudioSource audioSource = audioSourceTemp.AddComponent<AudioSource>();
            audioSource.clip = coinSound;
            // Đặt âm lượng của Audio Source tạm thời này lên 100%
            audioSource.volume = 1.0f; // 100% volume

            // Phát âm thanh từ Audio Source tạm thời tại vị trí hiện tại
            audioSource.Play();

            // Hủy Audio Source tạm thời sau khi phát xong âm thanh
            Destroy(audioSourceTemp, coinSound.length);
            Debug.Log("Đã phát nổ");

            // Kích hoạt Particle System của hiệu ứng nổ
            ParticleSystem explosion = Instantiate(explosionEffect, currentBom.transform.position, Quaternion.identity);
            explosion.Play();

            // Truy vấn danh sách các đối tượng trong bán kính phát nổ (2D)
            Collider2D[] colliders = Physics2D.OverlapCircleAll(currentBom.transform.position, explosionRadius);
            foreach (Collider2D col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Debug.Log("Đã trúng bom");
                    // Trừ máu cho đối tượng có tag "Enemy"
                    // (Đây chỉ là ví dụ, bạn cần thay đổi tương ứng với cách quản lý máu của đối tượng)
                    EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damageAmount);
                    }
                }
            }

            Destroy(currentBom); // Hủy object bom
        }
    }
}
