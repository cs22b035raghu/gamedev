using UnityEngine;
using UnityEngine.SceneManagement;

public class s : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            SceneManager.LoadScene("Scene4");  // Load a win screen
        }
    }
}
