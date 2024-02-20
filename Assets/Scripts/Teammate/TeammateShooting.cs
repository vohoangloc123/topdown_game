using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TeammateShooting : MonoBehaviour
{
    public GameObject bullter;
    public Transform bulletPos;
    private float timer;
    private GameObject player;
    public GameObject weaponObject;
    public GameObject weaponWore;
    [SerializeField]
    private Animator anim;
    private string levelUpTriggerName = "Shoot";
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
   void Update()
    {
        float distance= Vector2.Distance(transform.position,player.transform.position);
        // Debug.Log(distance);
        if(distance<10)
        {
            timer+=Time.deltaTime;
            if(timer>2)
            {
                timer=0;
                shoot();
                
            }
        }
    }
    void shoot()
    {
        // Debug.Log("Đã bắn");
        Instantiate(bullter,bulletPos.position,Quaternion.identity);
        if (anim != null)
        {
            // Kích hoạt trigger "Ding" trong Animator
            anim.SetTrigger(levelUpTriggerName);
                       
        }else
        {
            Debug.LogError("Animator reference is null!");
        } 
        weaponObject.SetActive(true);
        weaponWore.SetActive(false);
        StartCoroutine(HideWeapon());
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
}
