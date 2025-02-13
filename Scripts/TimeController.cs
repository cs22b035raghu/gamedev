using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeController : MonoBehaviour
{
    private float timeLimit = 60f;  // 1-minute countdown timer
    public float timeRemaining;
    private bool gameWon = false;

    public GameObject player;  // Reference to the player object
    private float targetZ = 842f;  // Z coordinate threshold to win the game



    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player object not assigned in the Inspector!");
        }

        timeRemaining = timeLimit;  // Set the starting time
        Debug.Log("Game Started. Time limit set to: " + timeLimit);
    }

    void Update()
    {
        if (gameWon)
        {
            SceneManager.LoadScene("ReportCrimeScene");
            Debug.Log("Game already won. No further updates.");
            return;  // Stop further updates when the game is won
        }

        Debug.Log($"Time Remaining: {timeRemaining:F2} seconds, Player Z: {player.transform.position.z},Player X :{player.transform.position.x}");

        CheckPlayerPosition();  // Check if player reached target Z

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; 
             // Countdown timer
            
        }
        else
        {
            SceneManager.LoadScene("LostScene");
            Debug.Log("Time's up! You lost!");
            //enabled = false;  // Stop further updates
        }
    }

    void CheckPlayerPosition()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is null!");
            return;
        }

        Debug.Log("Checking player position: " + player.transform.position.z);
        Debug.Log("Checking player position: " + player.transform.position.x);

        if (player.transform.position.z >= targetZ&&player.transform.position.x>=182)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        if (!gameWon)
        {
            gameWon = true;
            Debug.Log("You win! You reached Point B in time.");
            
        }
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }
}
