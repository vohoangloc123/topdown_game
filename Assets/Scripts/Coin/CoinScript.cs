using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool collected = false;
    public AudioClip coinSound;

    public int coinValue=100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collected) // Kiểm tra nếu player va chạm với coin
        {
            // Cộng điểm vào hệ thống điểm của bạn ở đây
            collected = true;
            PlayerCurrency.moneyValue += coinValue;

            // Tạo một Audio Source tạm thời để điều chỉnh âm lượng trước khi phát
            GameObject audioSourceTemp = new GameObject("TempAudio");
            AudioSource audioSource = audioSourceTemp.AddComponent<AudioSource>();
            audioSource.clip = coinSound;

            // Đặt âm lượng của Audio Source tạm thời này lên 100%
            audioSource.volume = 1.0f; // 100% volume

            // Phát âm thanh từ Audio Source tạm thời tại vị trí hiện tại
            audioSource.Play();

            // Hủy Audio Source tạm thời sau khi phát xong âm thanh
            Destroy(audioSourceTemp, coinSound.length);

            // Biến mất coin
            Destroy(gameObject);
        }
    }
}
