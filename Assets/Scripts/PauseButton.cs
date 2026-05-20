using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Attach this script to your pause button
    // Then in Unity, set the button's OnClick to call TogglePause()
    
    public void TogglePause()
    {
        GameManager.instance.TogglePause();
    }
}
