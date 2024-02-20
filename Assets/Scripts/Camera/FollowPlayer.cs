
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Trượt nhân vật vào đây trong Inspector.
    public Vector3 offset = new Vector3(0, 0, -10); // Để camera nằm trên nhân vật và có khoảng cách theo trục Z.
    public float zoomSpeed = 2.0f; // Tốc độ zoom.
    private float currentZoom = 0.0f; // Khoảng cách hiện tại.
    public Vector2 minBounds = new Vector2(-10, -10); // Giới hạn tọa độ X và Y tối thiểu.
    public Vector2 maxBounds = new Vector2(10, 10); // Giới hạn tọa độ X và Y tối đa.

    void Update()
    {
        if (target != null)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

            // Giới hạn khoảng cách (zoom) nếu bạn muốn.
            currentZoom = Mathf.Clamp(currentZoom, -8f, 8f);

            // Tạo một Vector3 mới cho offset với khoảng cách (zoom) đã điều chỉnh.
            Vector3 newOffset = offset + Vector3.forward * currentZoom;

            // Theo dõi nhân vật bằng cách cập nhật vị trí Camera
            Vector3 targetPosition = target.position + newOffset;

            // Giới hạn tọa độ X và Y của camera bằng cách sử dụng Mathf.Clamp
            float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

            // Cập nhật vị trí camera với tọa độ đã giới hạn
            transform.position = new Vector3(clampedX, clampedY, targetPosition.z);
        }
    }
}
