using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float countdownTime = 600.0f; // Thời gian đếm ngược ban đầu (10 phút = 600 giây)
    private Text countdownText;

    void Start()
    {
        // countdownText = GetComponent<Text>();
        countdownText = GetComponentInChildren<Text>();
        if (countdownText == null) {
            Debug.LogError("Không tìm thấy đối tượng Text!");
        }
        StartCountdown();
    }

    void StartCountdown()
    {
        InvokeRepeating("UpdateTimer", 0.0f, 1.0f); // Gọi hàm UpdateTimer mỗi giây
    }

    void UpdateTimer()
    {
        countdownTime -= 1.0f;
        DisplayTime(countdownTime);

        if (countdownTime <= 0.0f)
        {
            CancelInvoke("UpdateTimer");
            countdownText.text = "Finish!";
            LoadGameOverScene();
            // Thực hiện các hành động cần thiết khi đếm ngược kết thúc
            
        }
    }

    void DisplayTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = timerString;
    }
    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver"); // Thay "GameOver" bằng tên của scene GameOver
    }
}

