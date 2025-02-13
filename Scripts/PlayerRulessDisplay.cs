using UnityEngine;
using TMPro;

public class PlayerRulesDisplay : MonoBehaviour
{
    public GameObject rulesCanvas;  // The canvas containing the rules
    public TextMeshProUGUI rulesText;  // The TextMeshPro text object for the rules
    public Camera mainCamera;   // The main camera
    public Camera uiCamera;    // The UI-focused camera
    private CanvasGroup canvasGroup;  // CanvasGroup for controlling transparency

    void Start()
    {
        // Get the CanvasGroup component from the canvas
        canvasGroup = rulesCanvas.GetComponent<CanvasGroup>();

        // Initially set the canvas to be fully transparent (invisible)
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;  // Make canvas invisible
            canvasGroup.interactable = false;  // Prevent interaction
            canvasGroup.blocksRaycasts = false;  // Prevent blocking clicks
        }
        else
        {
            Debug.LogError("CanvasGroup not found on the canvas");
        }

        // Set the default camera to the main camera
        mainCamera.gameObject.SetActive(true);
        uiCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the visibility of the canvas
            if (canvasGroup.alpha == 0f)
            {
                ShowRulesCanvas();
            }
            else
            {
                HideRulesCanvas();
            }
        }
    }

    // Show the rules canvas
    void ShowRulesCanvas()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;  // Make canvas fully visible
            canvasGroup.interactable = true;  // Allow interaction with the canvas
            canvasGroup.blocksRaycasts = true;  // Allow clicks on the canvas

            // Switch to UI camera if necessary
            mainCamera.gameObject.SetActive(false);
            uiCamera.gameObject.SetActive(true);
        }
    }

    // Hide the rules canvas
    void HideRulesCanvas()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;  // Make canvas invisible
            canvasGroup.interactable = false;  // Prevent interaction
            canvasGroup.blocksRaycasts = false;  // Prevent clicks on the canvas

            // Switch back to main camera
            mainCamera.gameObject.SetActive(true);
            uiCamera.gameObject.SetActive(false);
        }
    }
}
