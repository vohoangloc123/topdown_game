using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopButtonHandler : MonoBehaviour
{
    
    public Button shopButton;
    public Button quitButton;
    public GameObject shop;
    private bool isGamePaused = false;
    public PlayerHealth playerHealth;
    public GameObject playerShootingGameObject;
    public ShopItem shopItemInstance;
    void Start()
    {
        quitButton.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenShop()
    {
      
        if (!isGamePaused)
        {
            // Tạm ngưng thời gian khi mở menu
            Time.timeScale = 0f;
            isGamePaused = true;

            // Hiển thị các nút cần thiết trong menu và ẩn nút menu
            shopButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(true);
            shop.gameObject.SetActive(true);
            
        }
    }
    public void ClickQuitShop()
    {
        shop.gameObject.SetActive(false); 
        shopButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        if (shopItemInstance != null)
        {
            shopItemInstance.ResetNotice();
        }
        else
        {
            Debug.Log("Reset notice not worked");
        }
    }
}
