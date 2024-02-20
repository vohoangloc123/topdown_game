using UnityEngine;

public class UIController : MonoBehaviour
{
    public Experiment experiment; // Tham chiếu đến script Experiment
    public GameObject upgradePanel; // Đối tượng panel upgrade

    // Hàm được gọi khi người chơi ấn vào nút để tăng sức mạnh
    public void UpgradeDamage()
    {
        // Thực hiện việc tăng sức mạnh cho class khác ở đây
        Debug.Log("Damage upgraded!");

        // Tiếp tục trò chơi
        Time.timeScale = 1f; // Tiếp tục thời gian trong trò chơi
        upgradePanel.SetActive(false); // Ẩn panel upgrade
        // experiment.expNeeded += 100; // Ví dụ tăng exp cần để lên level tiếp theo
    }
}
