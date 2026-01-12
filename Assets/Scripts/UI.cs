using UnityEngine;
using static GameManager;

public class UI: MonoBehaviour
{    
    [SerializeField] private GameObject _playScreenPanel;
    [SerializeField] private GameObject _deathScreenPanel;

    private void OnEnable ()
    {
        if (Instance != null)
        {
            Instance.OnGameStateChanged.AddListener(OnGameStateChanged);
        }
    }

    private void OnDisable ()
    {
        if (Instance != null)
        {
            Instance.OnGameStateChanged.RemoveListener(OnGameStateChanged);
        }
    }

    public void OnGameStateChanged (GameState newState)
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

    private void ShowPlayScreen ()
    {
        _playScreenPanel.SetActive(true);
        _deathScreenPanel.SetActive(false);
    }

    private void ShowDeathScreen ()
    {
        _playScreenPanel.SetActive(false);
        _deathScreenPanel.SetActive(true);
    }

    public void OnRestartButtonClicked ()
    {
        Instance.RestartGame();
    }
}