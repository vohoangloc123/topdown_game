using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Thêm namespace này để sử dụng UI elements trong Unity

public class CountKillScript : MonoBehaviour
{
    public static int killValue = 0;
    public Text kill; // Thay thế TextMeshProUGUI bằng Text

    // Start is called before the first frame update
    void Start()
    {
        kill = GetComponent<Text>();
        if (kill == null)
        {
            Debug.LogError("Text component is missing. Please attach a Text component to the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        kill.text = "Kills: " + killValue;
    }
    public static void ResetCountKillScript()
    {
        killValue=0;
    }
}
