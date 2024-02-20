using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experiment : MonoBehaviour
{
    public static int expValue = 0;
    public static int currentLevel = 1;
    public static int expNeeded = 100;

    public Text expText; // Thay thế TextMeshProUGUI bằng Text
    public GameObject increaseDamageButton; // Thay kiểu dữ liệu từ Button sang GameObject
    public GameObject increaseHpButton; // Thay kiểu dữ liệu từ Button sang GameObject
    public GameObject healingButton; // Thay kiểu dữ liệu từ Button sang GameObject

    public Image menuImage;
    public Slider expSlider;
    public static float constant = 100f; // Đây chỉ là một giá trị mẫu, bạn có thể điều chỉnh nó để phù hợp với trò chơi của mình
    void Start()
    {
        expText = GetComponent<Text>();
        if (expText == null)
        {
            Debug.LogError("Text component is missing. Please attach a Text component to the GameObject.");
        }
        else
        {
            expText.text = "lv." + currentLevel;
        }
        increaseDamageButton.SetActive(false);
        increaseHpButton.SetActive(false);
        healingButton.SetActive(false);
        menuImage.gameObject.SetActive(false);
    }

    public void CheckLevelUp()
    {
        if (expValue >= expNeeded)
        {
            LevelUp();
            increaseDamageButton.SetActive(true);
            increaseHpButton.SetActive(true);
            healingButton.SetActive(true);
            menuImage.gameObject.SetActive(true);
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        expNeeded = (int)(constant * Mathf.Sqrt(expValue));
        expValue = 0;
        if(expSlider != null)
        {
            expSlider.value = 0;
        }
        PauseGame();
        Debug.Log("Level Up! Now at Level " + currentLevel + " - Exp Needed: " + expNeeded);
        expText.text = "lv." + currentLevel;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void Update()
    {
        CheckLevelUp();
        if (expSlider != null)
        {
            expSlider.maxValue = expNeeded;
            expSlider.value = expValue;
        }
    }

    public static void ResetLevel()
    {
        currentLevel=1;
    }
}
