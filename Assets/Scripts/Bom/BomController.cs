
using UnityEngine;
using System.Collections;

public class BomController : MonoBehaviour
{
    public GameObject bomPrefab; // Prefab của object bom
    public Transform spawnPoint; // Vị trí để thả object bom
    private GameObject currentBom; // Object bom hiện tại


    void Update()
    {
        // Nếu nút E được nhấn
        if (Input.GetKeyDown(KeyCode.E))
        {
            ThrowBomb(); // Gọi hàm thả bom
        }
    }

    // Hàm để thả object bom
    public void ThrowBomb()
    {
        // Nếu object bom hiện tại không tồn tại
        if (currentBom == null)
        {
            // Tạo một object bom mới tại vị trí spawnPoint
            currentBom = Instantiate(bomPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
