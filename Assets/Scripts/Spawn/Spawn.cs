// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawn : MonoBehaviour
// {
//     public GameObject Prefab1; // Prefab 
//     public float spawnInterval1 = 1.0f; // Khoảng thời gian giữa mỗi lần spawn
//     public GameObject Prefab2; // Prefab 
//     public float spawnInterval2 = 1.0f; // Khoảng thời gian giữa mỗi lần spawn
//      public GameObject Prefab3; // Prefab 
//     public float spawnInterval3 = 1.0f; // Khoảng thời gian giữa mỗi lần spawn
//     public GameObject Prefab4; // Prefab 
//     public float spawnInterval4 = 1.0f; // Khoảng thời gian giữa mỗi lần spawn
    
//     public GameObject Prefab5; // Prefab 
//     public float spawnInterval5 = 1.0f; // Khoảng thời gian giữa mỗi lần spawn
//     public Vector2 areaSize; // Kích thước của limit area

//     private float timer = 0.0f;

//     void Update()
//     {
//         timer += Time.deltaTime;

//         if (timer >= spawnInterval1)
//         {
//             SpawnPrefab1();
//             timer = 0.0f;
//         }
//         if (timer >= spawnInterval2)
//         {
//             SpawnPrefab2();
//             timer = 0.0f;
//         }
//         if (timer >= spawnInterval3)
//         {
//             SpawnPrefab3();
//             timer = 0.0f;
//         }
//         if (timer >= spawnInterval4)
//         {
//             SpawnPrefab4();
//             timer = 0.0f;
//         }
//         if (timer >= spawnInterval5)
//         {
//             SpawnPrefab5();
//             timer = 0.0f;
//         }
//     }

//     void SpawnPrefab1()
//     {
//         Vector2 spawnPosition = new Vector2(
//             Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
//             Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
//         );

//         Instantiate(Prefab1, spawnPosition, Quaternion.identity);
//     }
//      void SpawnPrefab2()
//     {
//         Vector2 spawnPosition = new Vector2(
//             Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
//             Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
//         );

//         Instantiate(Prefab2, spawnPosition, Quaternion.identity);
//     }
//      void SpawnPrefab3()
//     {
//         Vector2 spawnPosition = new Vector2(
//             Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
//             Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
//         );

//         Instantiate(Prefab3, spawnPosition, Quaternion.identity);
//     }
//      void SpawnPrefab4()
//     {
//         Vector2 spawnPosition = new Vector2(
//             Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
//             Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
//         );

//         Instantiate(Prefab4, spawnPosition, Quaternion.identity);
//     }
//      void SpawnPrefab5()
//     {
//         Vector2 spawnPosition = new Vector2(
//             Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
//             Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
//         );

//         Instantiate(Prefab5, spawnPosition, Quaternion.identity);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefabs; // Mảng các Prefab
    public float[] spawnIntervals; // Mảng thời gian giữa mỗi lần spawn
    public Vector2 areaSize; // Kích thước của limit area

    private float[] timers; // Mảng timer cho từng prefab

    void Start()
    {
        timers = new float[prefabs.Length];
    }

    void Update()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            timers[i] += Time.deltaTime;

            if (timers[i] >= spawnIntervals[i])
            {
                SpawnPrefab(i);
                timers[i] = 0.0f;
            }
        }
    }

    void SpawnPrefab(int prefabIndex)
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2),
            Random.Range(transform.position.y - areaSize.y / 2, transform.position.y + areaSize.y / 2)
        );

        Instantiate(prefabs[prefabIndex], spawnPosition, Quaternion.identity);
    }
}
