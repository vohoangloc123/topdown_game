using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    public FireballController fireballController;
    public int upgradedNumberOfFireballs=1; // Số lượng Fireball sau khi nâng cấp
    public GameObject fireball;

    public static FireballManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Gọi khi người chơi nâng cấp Fireball
    public void UpgradeFireball(int currentLevel)
    {
        if(currentLevel==1&& fireball != null)
        {
            fireball.SetActive(true);
        }else
        {
            fireballController.numberOfFireballs += upgradedNumberOfFireballs;
            fireballController.CreateFireballs();
            Debug.Log("Đã nâng số lượng fire balls");
        }

        
    }
}
