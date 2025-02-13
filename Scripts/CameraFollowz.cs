using UnityEngine;

public class CameraFollowz : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player; // Reference to the player
    public Vector3 offset = new Vector3(0, 1.6f, 0); // Adjust height to match player's head

    void Update()
    {
        // Make the camera follow the player's position without rotation changes
        transform.position = player.position + offset;
        transform.rotation = player.rotation; // Ensures camera faces wherever the player is facing
    }
}
