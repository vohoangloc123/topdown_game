using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public Button startGameButton;
    public Button quitButton;

    void Start()
    {
        // Lắng nghe sự kiện khi người chơi ấn vào nút "Start Game"
        if (startGameButton != null)
        {
            startGameButton.onClick.AddListener(StartGame);
        }

        // Lắng nghe sự kiện khi người chơi ấn vào nút "Quit"
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    public void StartGame()
    {
        // Load scene có tên là "MainScene"
        SceneManager.LoadScene("GamePlay");
        ScoreScript.ResetScore();
        Experiment.ResetLevel();
        EnemySpawner.ResetEnemySpawner();
        CountKillScript.ResetCountKillScript();
        BulletScript.ResetBulletScript();
        PlayerCurrency.ResetMoney();
    }

    public void QuitGame()
    {
        // Thoát game khi người chơi ấn nút "Quit"
        Application.Quit();
    }
}
