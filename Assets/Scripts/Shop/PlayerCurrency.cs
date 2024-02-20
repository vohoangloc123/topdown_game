using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class PlayerCurrency : MonoBehaviour
{
    public static int moneyValue = 100000;
    public Text money; // Thay thế TextMeshProUGUI bằng Text

    // Start is called before the first frame update
    void Start()
    {
        money = GetComponent<Text>();
        if (money == null)
        {
            Debug.LogError("Text component is missing. Please attach a Text component to the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + moneyValue;
    }
    public static void ResetMoney()
    {
        moneyValue=0;
    }
    public static bool HasEnoughMoney(int amount)
    {
        return moneyValue >= amount;
    }

    public static void SpendMoney(int amount)
    {
        if (moneyValue >= amount)
        {
            moneyValue -= amount;
        }
        else
        {
            Debug.LogWarning("Not enough money to spend.");
            // Có thể thông báo rằng người chơi không đủ tiền để mua một thứ gì đó ở đây
        }
    }

    public static void AddMoney(int amount)
    {
        moneyValue += amount;
    }
}
