using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; //một đối tượng (GameObject) được sử dụng để tạo ra đạn khi bắn
    public Transform launchPoint; //là một đối tượng (Transform) định vị vị trí bắn.

    public float shootTime; //là thời gian giữa mỗi lần bắn
    public float shootCounter; //đếm thời gian còn lại trước khi có thể bắn lần tiếp theo.
    public GameObject weaponObject;
    public GameObject weaponWore;
    public string button;
    public AudioSource resumeSound;
    // Start is called before the first frame update
    [SerializeField]
    private Animator anim;
    private string levelUpTriggerName = "Shoot";
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(button) && shootCounter <= 0)
        {
            if (projectilePrefab != null) // Kiểm tra đối tượng projectilePrefab có tồn tại hay không
            {
                Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
                shootCounter = shootTime;
                  // Hiển thị object Weapon
                if (weaponObject != null)
                {
                    PlaySound();
                    if (anim != null)
                    {
                        // Kích hoạt trigger "Ding" trong Animator
                        anim.SetTrigger(levelUpTriggerName);
                       
                    }
                    else
                    {
                        Debug.LogError("Animator reference is null!");
                    } 
                    weaponObject.SetActive(true);
                    weaponWore.SetActive(false);
                    StartCoroutine(HideWeapon());
                }
            }
        }
    shootCounter -= Time.deltaTime;
    } 
    IEnumerator HideWeapon()
    {
        // Chờ một khoảng thời gian và sau đó ẩn đi object Weapon
        yield return new WaitForSeconds(1f); // Thay đổi thời gian tùy ý
        if (weaponObject != null)
        {
            weaponObject.SetActive(false);
            weaponWore.SetActive(true);
        }
    }
    public void PlaySound()
    {
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
}

