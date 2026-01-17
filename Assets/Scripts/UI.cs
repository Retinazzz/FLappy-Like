using UnityEngine;
using static GameManager;

public class UI: MonoBehaviour
{    
    [SerializeField] private GameObject _playScreenPanel;
    [SerializeField] private GameObject _deathScreenPanel;
    [SerializeField] private GameManager _gameManager;
    private void OnEnable()
    {
        if (_gameManager != null)
        {
            _gameManager.OnGameStateChanged.AddListener(OnGameStateChanged);
        }
    }

    private void OnDisable()
    {
        if (_gameManager != null)
        {
            _gameManager.OnGameStateChanged.RemoveListener(OnGameStateChanged);
        }
    }

    public void OnGameStateChanged(GameState newState)
    {        
        switch (newState)
        {
            case GameState.PlayScreen:
                {
                    ShowPlayScreen();
                    break;
                }
               
            case GameState.DeathScreen:
                {
                    ShowDeathScreen();
                    break;
                }                
        }
    }

    private void ShowPlayScreen()
    {
        _playScreenPanel.SetActive(true);
        _deathScreenPanel.SetActive(false);
    }

    private void ShowDeathScreen()
    {
        _playScreenPanel.SetActive(false);
        _deathScreenPanel.SetActive(true);
    }

    public void OnRestartButtonClicked()
    {
        _gameManager.RestartGame();
    }
}