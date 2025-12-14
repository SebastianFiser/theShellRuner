using UnityEngine;
using UnityEngine.UI;

public class Fullscreen_toggle : MonoBehaviour
{
    [Header ("Starting Position")]
    [Header("Inspector")]
    [Tooltip("Assign the GameObject (checkmark) that should be shown when fullscreen is active.")]
    [SerializeField] private GameObject checkmark;

    [Header("Start Value")]
    [SerializeField] private bool startFullscreen = false;
    
    [Header("Toggle (optional)")]
    [Tooltip("Optional: assign the Toggle that controls fullscreen. If left empty, the script will try to find a Toggle on the same GameObject.")]
    [SerializeField] private Toggle targetToggle;
        
    private void Start()
    {
        Screen.fullScreen = startFullscreen;
        // Ensure initial fullscreen state and sync checkmark
        ApplyCheckmarkVisibility(Screen.fullScreen);
        Debug.Log($"FullscreenToggle: initial state is {(Screen.fullScreen ? "fullscreen" : "windowed")}");

        // If no toggle assigned, try to find one on this GameObject
        if (targetToggle == null)
            targetToggle = GetComponent<Toggle>();

        if (targetToggle != null)
        {
            // Set toggle state to match fullscreen without invoking its listeners
            targetToggle.SetIsOnWithoutNotify(Screen.fullScreen);
            // Subscribe to changes so UI toggle drives fullscreen
            targetToggle.onValueChanged.AddListener(SpriteChange);
            Debug.Log($"FullscreenToggle: subscribed to Toggle on '{targetToggle.gameObject.name}' and initial state is {(Screen.fullScreen ? "fullscreen" : "windowed")}");
        }
    }

    // Button-friendly toggle: no parameter, simply flip fullscreen
    public void SpriteChange()
    {
        bool isFull = !Screen.fullScreen;
        Screen.fullScreen = isFull;
        ApplyCheckmarkVisibility(isFull);
        Debug.Log($"FullscreenToggle: game is now {(isFull ? "fullscreen" : "not fullscreen")} (SpriteChange())");
    }

    // Toggle-friendly method: accepts the desired fullscreen state
    public void SpriteChange(bool isFull)
    {
        Screen.fullScreen = isFull;
        ApplyCheckmarkVisibility(isFull);
        Debug.Log($"FullscreenToggle: game is now {(isFull ? "fullscreen" : "not fullscreen")} (SpriteChange(bool))");
    }

    private void OnDestroy()
    {
        if (targetToggle != null)
        {
            targetToggle.onValueChanged.RemoveListener(SpriteChange);
            Debug.Log("FullscreenToggle: unsubscribed from Toggle.onValueChanged");
        }
        else
        {
            Debug.Log("FullscreenToggle: OnDestroy called, no Toggle was subscribed");
        }
    }

    // Helper: show/hide the checkmark safely
    private void ApplyCheckmarkVisibility(bool isVisible)
    {
        if (checkmark == null)
        {
            Debug.LogWarning("FullscreenToggle: checkmark GameObject is not assigned in the Inspector.");
            return;
        }

        checkmark.SetActive(isVisible);
        Debug.Log($"FullscreenToggle: checkmark set to {(isVisible ? "visible" : "hidden")}");
    }

    
    
}
