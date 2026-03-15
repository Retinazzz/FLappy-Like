using UnityEngine;
using static GameManager;

public class UI: MonoBehaviour , IService
{    
    [SerializeField] private GameObject _playScreenPanel;
    [SerializeField] private GameObject _deathScreenPanel;
    private  GameManager _gameManager;    

    private void Start()
    {
        _gameManager = ServiceLocator.Get<GameManager>();
        _gameManager.OnGameStateChanged += StateChanged;        
    }

    public void StateChanged(GameState newState)
    {        
        switch (newState)
        {
            case GameState.PlayScreen:
                {
                    ShowPlayScreen();
                    Debug.Log("show1");
                    break;
                }
               
            case GameState.DeathScreen:
                {
                    ShowDeathScreen();
                    Debug.Log("show2");
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
    private void OnDisable()
    {
        _gameManager.OnGameStateChanged -= StateChanged;
    }
}