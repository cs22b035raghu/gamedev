using UnityEngine;
using UnityEngine.SceneManagement;

public class ReportCrimeUI : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("You reported the crime. You win!");
            SceneManager.LoadScene("WinScene");  // Load a win screen
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("You ignored the crime. You lose!");
            SceneManager.LoadScene("LostScene");  // Load a lose screen
        }
    }
}
