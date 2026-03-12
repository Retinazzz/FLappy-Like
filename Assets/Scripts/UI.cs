using UnityEngine;
using static GameManager;

public class UI: MonoBehaviour , IService
{    
    [SerializeField] private GameObject _playScreenPanel;
    [SerializeField] private GameObject _deathScreenPanel;      
                
    private void Start()
    {        
        if (ServiceLocator.Get<GameManager>() == null)
        {
            Debug.LogError("GameManager не найден!");
            return;
        }        
        ServiceLocator.Get<GameManager>().OnGameStateChanged.AddListener(StateChanged);        
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
        ServiceLocator.Get<GameManager>().RestartGame();
    }
    private void OnDisable()
    {
        ServiceLocator.Get<GameManager>().OnGameStateChanged.RemoveAllListeners();
    }
}