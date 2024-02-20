
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public enum ItemType
    {
        Fireball,
        TeammateAlex,
        TeammateMina,
        TeammateMorris
        // Thêm các loại kỹ năng khác ở đây nếu cần
    }

    public ItemType itemType;
    public int baseLevel = 0; // Cấp độ cơ bản của kỹ năng
    public int maxLevel = 5; // Cấp độ tối đa của kỹ năng
    public int upgradeCost = 10; // Chi phí nâng cấp mỗi cấp độ

    private int currentLevel;
    public Text levelText;
    public Text priceText;
    public Text noticeText;
    public int upgradePrice;

    private void Start()
    {
        currentLevel = baseLevel;
        UpdateUI();
    }

    void Update()
    {
       
    }

    private void UpdateUI()
    {
        levelText.text = "Level: " + currentLevel;

        if (currentLevel < maxLevel)
        {
            upgradePrice = (currentLevel + 1) * upgradeCost;
            priceText.text = upgradePrice.ToString(); // Hiển thị giá tiền nâng cấp lên Text
        }
        else
        {
            priceText.text = "Max"; // Hiển thị chữ "Max" khi đạt cấp độ tối đa
        }
    }

    public void UpgradeSkill()
    {
        if (currentLevel < maxLevel)
        {
            upgradePrice = (currentLevel + 1) * upgradeCost;
            if (PlayerCurrency.HasEnoughMoney(upgradePrice))
            {
                PlayerCurrency.SpendMoney(upgradePrice);
                currentLevel++;
                UpdateUI(); // Cập nhật UI sau khi nâng cấp

                UpgradeItem(itemType);
                
                Debug.Log(itemType.ToString() + " has been upgraded to level " + currentLevel);
                string s=itemType.ToString() + " has been upgraded to level " + currentLevel;
                noticeText.text = s.ToString();
            }
            else
            {
                Debug.Log("Not enough money to upgrade " + itemType.ToString());
                noticeText.text = "Not enough money to upgrade";
            }
        }
        else
        {
            Debug.Log(itemType.ToString() + " is already at max level");
            string s=itemType.ToString() + " is already at max level";
            noticeText.text = s.ToString();
        }
    }

    private void UpgradeItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.Fireball:
                FireballManager.Instance.UpgradeFireball(currentLevel);
                break;
            case ItemType.TeammateAlex:
                // Gọi hàm nâng cấp cho OtherSkill1
                TeammateManager.Instance.UpgradeTeammate(currentLevel);
                break;
            case ItemType.TeammateMina:
                // Gọi hàm nâng cấp cho OtherSkill24
                TeammateMinaManager.Instance.UpgradeTeammate(currentLevel);
                break;
                case ItemType.TeammateMorris:
                // Gọi hàm nâng cấp cho OtherSkill24
                TeammateMorrisManager.Instance.UpgradeTeammate(currentLevel);
                break;
            // Xử lý nâng cấp cho các loại kỹ năng khác ở đây
            default:
                break;
        }
    }
    public void ResetNotice()
    {
        if (noticeText != null)
        {
            noticeText.text = "";
        }
    }
}
