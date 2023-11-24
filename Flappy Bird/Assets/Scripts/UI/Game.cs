using System.Runtime.InteropServices;
using UnityEngine;

public class Game : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAds();

    [SerializeField] private Bird _bird;
    [SerializeField] private TowerGenerator _towerGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _towerGenerator.ResetTower();
        StartGame();
        _audioSource.Play();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        _gameOverScreen.Open();
        _audioSource.Stop();
        ShowAds();
    }
}