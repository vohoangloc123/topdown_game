using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateMorrisManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teammate;

    public static TeammateMorrisManager Instance { get; private set; }
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
    public void UpgradeTeammate(int currentLevel)
    {
        if (currentLevel == 1 && teammate != null)
        {
            teammate.SetActive(true); // Hiển thị đối tượng teammate khi cấp độ Fireball đạt mức 1
        }else
        {
            BomScript.damageAmount+=50;
            Debug.Log("Đã nâng: "+BomScript.damageAmount);
        }
    }
}
