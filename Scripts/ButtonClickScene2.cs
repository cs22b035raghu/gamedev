using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickScene2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadNewScene()
    {
        SceneManager.LoadScene("Scene3");
    }
}
