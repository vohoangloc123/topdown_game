using UnityEngine;
public class FireballController : MonoBehaviour
{
    public GameObject fireballPrefab;
    public int numberOfFireballs = 1;
    public float circleRadius = 2f;
    public float rotationSpeed = 2f;
    
    private void Start()
    {
        
        CreateFireballs();
    }

    public void CreateFireballs()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < numberOfFireballs; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfFireballs;
            Vector3 newPosition = transform.position + new Vector3(Mathf.Cos(angle) * circleRadius, Mathf.Sin(angle) * circleRadius, 0);
            GameObject fireball = Instantiate(fireballPrefab, newPosition, Quaternion.identity);
            // Đặt fireball là con của nhân vật hoặc đối tượng gốc nếu cần thiết
            fireball.transform.parent = transform;

            // Góc quay của viên lửa
            float rotation = i * 360f / numberOfFireballs;
            fireball.transform.Rotate(0, 0, rotation);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

}

