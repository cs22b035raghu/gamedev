using UnityEngine;
public class PlayerCarInteraction : MonoBehaviour
{
    public GameObject player;   // The player character
    public GameObject car;      // The car
    public Camera playerCamera; // Camera for player view
    public Camera carCamera;    // Camera for car view

    private bool isNearCar = false;   // Checks if player is near the car
    private bool isDriving = false;   // Tracks current mode
    private float horizontalInput;    // Horizontal movement input
    private float verticalInput;      // Vertical movement input
    private float speed = 10f;      
      // Movement speed
  
    void Start()
    {
        // Initially, enable player movement and disable car movement
        player.GetComponent<PlayerMovements>().enabled = true;
        car.GetComponent<PlayerMovements>().enabled = false;

        // Enable player camera and disable car camera
        playerCamera.enabled = true;
        carCamera.enabled = false;
    }

    void Update()
    {
        // Get input for movement (applies to both car and player)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // If the player is near the car and presses 'Y', switch to the car
        if (isNearCar && Input.GetKeyDown(KeyCode.Y) && !isDriving)
        {
            SwitchToCar();
        }
        // If the player is driving the car and presses 'E', switch back to the player
        else if (isDriving && Input.GetKeyDown(KeyCode.E))
        {
            SwitchToPlayer();
        }

        // If driving, move both player and car together, else move only the player
        if (isDriving)
        {
            MoveTogether();
        }
        else if (!isDriving)
        {
            MovePlayer();
        }
    }

    // When the player enters the car's collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == car)
        {
            isNearCar = true;
            Debug.Log("Press 'Y' to enter the car");
        }
    }

    // When the player exits the car's collider
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == car)
        {
            isNearCar = false;
            Debug.Log("You left the car area");
        }
    }

    // Switch control to the car
    void SwitchToCar()
    {
        isDriving = true;
        //player.GetComponent<PlayerMovements>().enabled = false;
        car.GetComponent<PlayerMovements>().enabled = true;
        //player.gameObject.SetActive(false);
        player.GetComponent<Renderer>().enabled = false; 
        // Switch camera to car
        playerCamera.enabled = false;
        carCamera.enabled = true;
        Debug.Log("Switched to car. Press 'E' to exit.");
    }

    // Switch control back to the player
    void SwitchToPlayer()
    {
        isDriving = false;
        //player.GetComponent<PlayerMovements>().enabled = true;
        car.GetComponent<PlayerMovements>().enabled = false;
        player.GetComponent<Renderer>().enabled = true; 
        //player.gameObject.SetActive(true);
        // Switch camera to player
        playerCamera.enabled = true;
        carCamera.enabled = false;
        Debug.Log("Switched to player. Press 'Y' to enter the car again.");
    }

    // Move both player and car together
    void MoveTogether()
    {
        // Apply movement input to both player and car only if in driving mode
        player.transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        player.transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        car.transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        car.transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    // Move player independently when not in the car
    void MovePlayer()
    {
        // Apply movement input to only the player when not driving the car

        player.transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        player.transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}