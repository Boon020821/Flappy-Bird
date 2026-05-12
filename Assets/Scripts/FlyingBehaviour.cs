
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rb;
    // private bool _isGameStarted = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        // // Initially disable gravity and input until game starts
        // _rb.gravityScale = 0;
        // _rb.linearVelocity = Vector2.zero;
    }

    private void Update()
    {
        // // Only respond to input if game has started
        // if (!_isGameStarted) return;

        // Check for mouse click OR spacebar press
        if ((Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) || 
            Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        { 
            _rb.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        // Only apply rotation if game has started
        // if (!_isGameStarted) return;

        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Only trigger game over if game has started
        // if (!_isGameStarted) return;

        GameManager.instance.GameOver();
    }

    // // Call this method to start the game (called by StartScreen)
    // public void StartGame()
    // {
    //     _isGameStarted = true;
    //     _rb.gravityScale = 0.65f; // Restore gravity
    // }
}