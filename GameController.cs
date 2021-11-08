using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartSceen _startSceen;
    [SerializeField] private GameOverSceen _gameOverSceen;
    
    

    private void Start()
    {
        Time.timeScale = 0;
        _gameOverSceen.Close();
        _startSceen.Open();
        
    }
    private void OnEnable()
    {
        _startSceen.PlayButtonClick += OnPlayButtonClick;
        _gameOverSceen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += GameOver;
    }
    private void OnDisable()
    {
        _startSceen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverSceen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= GameOver;
    }
    private void OnPlayButtonClick()
    {
        _startSceen.Close();
        StartGame();
    }
    private void OnRestartButtonClick()
    {
        _gameOverSceen.Close();
        _pipeGenerator.ResetPool();
        StartGame();

    }
    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverSceen.Open();


    }
}
