using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;
    [SerializeField]
    private GameObject bossSwarmerPrefab;
    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 6.5f;
    [SerializeField]
    private float bossSwarmerInterval = 10.4f;
    [SerializeField]
    static public int enemySpawnCount = 0;
    [SerializeField]
    public static int maxEnemySpawns = 5;
    public static int enemyDefeated=  0;
    [SerializeField]
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
        StartCoroutine(spawnEnemy(bossSwarmerInterval, bossSwarmerPrefab));
    }

    // private IEnumerator spawnEnemy(float interval, GameObject enemy)
    // {
    //     if (enemySpawnCount>=maxEnemySpawns)
    //     {
    //         // Đã sinh ra đủ số lượng quái vật, không sinh thêm
    //         yield break;
    //     }

    //     yield return new WaitForSeconds(interval);

    //     // Lấy vị trí của object chứa script để xác định vị trí spawn
    //     Vector3 spawnPosition = transform.position;

    //     GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
    //     enemySpawnCount++;
    //     StartCoroutine(spawnEnemy(interval, enemy));
    // }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        while (true) // Sử dụng vòng lặp vô hạn để luôn thực hiện việc spawn
        {
            if (enemySpawnCount >= maxEnemySpawns)
            {
                // Đã sinh ra đủ số lượng quái vật, không sinh thêm
                yield return null; // Chờ một frame để kiểm tra lại điều kiện
            }
            else
            {
                yield return new WaitForSeconds(interval);

                // Lấy vị trí của object chứa script để xác định vị trí spawn
                Vector3 spawnPosition = transform.position;

                GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
                enemySpawnCount++;
            }
        }
    }

    public static void whenAllTheEnemyDefeated()
    {
        enemyDefeated++;
        // Debug.Log("Số quái đã giết: "+enemyDefeated);
        if (enemyDefeated >= maxEnemySpawns)
        {
            // Đã sinh ra đủ số lượng quái vật, không sinh thêm
            enemySpawnCount=0;
            // Debug.Log("Enemy spawn count after reset: "+enemySpawnCount);
            enemyDefeated=0;
            // Debug.Log("Enemy defeated after reset: "+enemyDefeated);
            Experiment.currentLevel+=1;
            // Debug.Log("level: "+level);
            maxEnemySpawns+=2;
            Debug.Log("Current enemy spawn: "+maxEnemySpawns);
        }
    }
    public static void ResetEnemySpawner()
    {
        enemyDefeated=0;
        enemySpawnCount=0;
        maxEnemySpawns=5;
    }
}
