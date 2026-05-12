// using UnityEngine;
// using UnityEngine.InputSystem;

// public class StartScreen : MonoBehaviour
// {
//     [SerializeField] private GameObject _startPanel;
//     [SerializeField] private FlyingBehaviour _birdFlyingBehaviour;
//     [SerializeField] private Score _score;

//     private void Start()
//     {
//         // Show start screen
//         if (_startPanel != null)
//         {
//             _startPanel.SetActive(true);
//         }
        
//         // Pause the game
//         Time.timeScale = 0f;
//     }

//     private void Update()
//     {
//         // Check for input to start the game
//         bool mouseClick = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
//         bool spacePress = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
//         bool tap = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

//         if (mouseClick || spacePress || tap)
//         {
//             StartGame();
//         }
//     }

//     private void StartGame()
//     {
//         Debug.Log("Starting game...");
        
//         // Start the bird's flying behavior
//         if (_birdFlyingBehaviour != null)
//         {
//             _birdFlyingBehaviour.StartGame();
//         }
        
//         // Show the scores when game starts
//         if (_score != null)
//         {
//             _score.StartGame();
//         }
        
//         // Resume time
//         Time.timeScale = 1f;
        
//         // Hide start panel
//         if (_startPanel != null)
//         {
//             _startPanel.SetActive(false);
//         }
        
//         // Disable this script so it doesn't run anymore
//         enabled = false;
//     }
// }