using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab của đồng xu
    public float spawnInterval = 1.0f; // Khoảng thời gian giữa mỗi lần spawn
    public Vector2 areaSize; // Kích thước của limit area

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0.0f;
        }
    }

    void SpawnCoin()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
            Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
        );

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
