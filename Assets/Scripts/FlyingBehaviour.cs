
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _scoreCanvas;

    private Rigidbody2D _rb;
    private float _originalGravityScale; // 保存Rigidbody2D组件中设置的原始重力值

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        // 保存Inspector中设置的重力值
        _originalGravityScale = _rb.gravityScale;
        
        // 立即关闭重力，防止游戏开始前鸟掉落
        _rb.gravityScale = 0;
        _rb.linearVelocity = Vector2.zero;
    }

    private void Start()
    {
        // 确保游戏开始时鸟保持悬浮状态
        _rb.gravityScale = 0;
        _rb.linearVelocity = Vector2.zero;
    }

    private void Update()
    {
        // 游戏暂停或结束时，不处理任何输入
        if (GameManager.instance._isPaused)
            return;

        // 游戏未开始时，不处理点击（只在第一次点击时启动游戏）
        // 注意：第一次点击是通过检查 _rb.gravityScale == 0 来判断的

        // Check for mouse click OR spacebar press
        if ((Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) || 
            Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        { 
            // 第一次点击时开启重力，通知 GameManager 游戏开始
            if (_rb.gravityScale == 0)
            {
                _rb.gravityScale = _originalGravityScale; // 使用Rigidbody2D组件中设置的重力值
                GameManager.instance.StartGame();
            }
            _rb.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        // 只有游戏开始后才应用旋转
        if (_rb.gravityScale == 0) return;

        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // 只有游戏开始后才触发 Game Over
        if (_rb.gravityScale == 0) return;

        _scoreCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.GameOver();
    }

    // // Call this method to start the game (called by StartScreen)
    // public void StartGame()
    // {
    //     _isGameStarted = true;
    //     _rb.gravityScale = 0.65f; // Restore gravity
    // }
}