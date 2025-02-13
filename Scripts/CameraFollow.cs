using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag the player object here in the Inspector
    public Vector3 offset = new Vector3(0, 0, 0); // Position offset from the player
    public float smoothSpeed = 0.125f; // Adjust to control how smooth the camera movement is

    void LateUpdate()
    {
        // Calculate the target position
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Ensure the camera always looks at the player
        transform.LookAt(player);
    }
}