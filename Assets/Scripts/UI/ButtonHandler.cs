using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Button increaseDamageButton; // Thêm Button để tăng sức mạnh damage
    public Button increaseHpButton; // Thêm Button để tăng sức mạnh damage
    public Button HealingButton; // Thêm Button để tăng sức mạnh damage
    public PlayerHealth playerHealth;
    public GameObject playerShootingGameObject;

    [SerializeField]
    private Animator anim;
    public AudioSource resumeSound;
    private string levelUpTriggerName = "Ding";
    
    public Button menuButton;
    public Button resumeButton;
    public Button quitButton;
    private bool isGamePaused = false;
    public Image menuImage;
    void Start()
    {
        quitButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseDamage()
    {
        
        if (playerShootingGameObject != null)
        {
            // Truy cập PlayerShooting từ GameObject
            PlayerShooting playerShooting = playerShootingGameObject.GetComponent<PlayerShooting>();

            // Kiểm tra xem playerShooting có tồn tại và có đối tượng đạn không
            if (playerShooting != null && playerShooting.projectilePrefab != null)
            {
                // Truy cập script BulletScript từ đối tượng đạn và điều chỉnh giá trị damage
                // BulletScript bulletScript = playerShooting.projectilePrefab.GetComponent<BulletScript>();
                // if (bulletScript != null)
                // {
                //     bulletScript.damage += 100; // Tăng giá trị damage của đạn
                //     Debug.Log("current damage: "+bulletScript.damage);
                //     // Debug.Log("Current damage: "+bulletScript.damage);
                // }
                BulletScript.damage += 100; // Tăng giá trị damage của đạn
                Debug.Log("current damage: "+BulletScript.damage);
            }
        }
        ResumeGame();
        Debug.Log("Damage Increased!"); // Đây chỉ là ví dụ, bạn cần thay đổi để tăng sức mạnh damage thực tế
       
    }
    
    public void IncreasHp()
    {
        
        ResumeGame();
        playerHealth.maxHealth+=100;
        playerHealth.UpdateHealthBar();
        Debug.Log("Current max health: "+playerHealth.maxHealth);
        Debug.Log("Hp Increased!"); // Đây chỉ là ví dụ, bạn cần thay đổi để tăng sức mạnh damage thực tế 
    }
    public void Healing()
    {
        ResumeGame();
         if (playerHealth != null)
        {
            // playerHealth.health += 400; // Tăng máu của người chơi khi nhấn nút Healing
            // playerHealth.UpdateHealthBar(); // Cập nhật thanh máu sau khi tăng máu
            int healAmount = 400;
            int remainingSpace = playerHealth.maxHealth - playerHealth.health;
            healAmount = Mathf.Min(healAmount, remainingSpace); // Giới hạn hồi máu không vượt quá khoảng trống còn lại

            playerHealth.Heal(healAmount);
        }
        else
        {
            Debug.LogError("PlayerHealth reference is null!");
        }
        Debug.Log("Healing!");
    }
    public void ResumeGame()
    {
        Debug.Log("Working here!");
        Time.timeScale = 1f; // Tiếp tục thời gian trong trò chơi
        increaseDamageButton.gameObject.SetActive(false); // Ẩn nút tăng sức mạnh damage sau khi đã tăng
        increaseHpButton.gameObject.SetActive(false); // Ẩn nút tăng sức mạnh damage sau khi đã tăng
        HealingButton.gameObject.SetActive(false); // Ẩn nút tăng sức mạnh damage sau khi đã tăng
        menuImage.gameObject.SetActive(false);
        if (anim != null)
        {
            // Kích hoạt trigger "Ding" trong Animator
            anim.SetTrigger(levelUpTriggerName);
        }
        else
        {
            Debug.LogError("Animator reference is null!");
        }
        if(resumeSound != null)
        {
            // Phát âm thanh
            resumeSound.Play();
        }
        else
        {
            Debug.LogError("AudioSource reference is null!");
        }
    }
    public void OpenMenu()
    {
      
        if (!isGamePaused)
        {
            // Tạm ngưng thời gian khi mở menu
            Time.timeScale = 0f;
            isGamePaused = true;

            // Hiển thị các nút cần thiết trong menu và ẩn nút menu
            menuButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            
        }
    }
    public void ClickResume()
    {
        menuButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void ClickQuit()
    {
        Application.Quit();
    }
}
