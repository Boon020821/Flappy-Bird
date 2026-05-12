using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    // [SerializeField] private TextMeshProUGUI _scoreLabel;
    // [SerializeField] private TextMeshProUGUI _bestLabel;
    
    private int _score;
    private int _highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentScoreText.text = _score.ToString();

        // Load the saved high score
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScoreText.text = _highScore.ToString();
        
        // // Hide scores and labels on start screen
        // _currentScoreText.gameObject.SetActive(false);
        // _highScoreText.gameObject.SetActive(false);
        
    }

    private void UpdateHighScore()
    {
        // Only update if current score is higher than saved high score
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save(); // Important: Save to disk
            _highScoreText.text = _highScore.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }

    // public void StartGame()
    // {
    //     // Show the scores and labels when game starts
    //     _currentScoreText.gameObject.SetActive(true);
    //     _highScoreText.gameObject.SetActive(true);
        
    // }
}