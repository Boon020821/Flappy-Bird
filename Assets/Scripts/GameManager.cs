using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _scoreCanvas;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _pauseImage;  // PlayingCanvas/Pause
    [SerializeField] private GameObject _playImage;   // PlayingCanvas/Play

    public bool _isGameStarted = false;
    public bool _isPaused = false; // 跟踪暂停状态

    private void Awake()
    {
        if (instance == null) 
        {
           instance = this;
        }

        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        _startScreen.SetActive(false);
        _scoreCanvas.SetActive(true);

        _isGameStarted = true;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        _pauseImage.SetActive(false);
        _playImage.SetActive(false);
        
        Time.timeScale = 0f; // 暂停游戏
        _isPaused = true;
    }

    // 暂停/继续游戏
    public void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0f : 1f;
        
        // 切换暂停和播放图标的显示
        _pauseImage.SetActive(!_isPaused);  // 暂停时隐藏pause图标
        _playImage.SetActive(_isPaused);    // 暂停时显示play图标
    }

    public void ResstartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
