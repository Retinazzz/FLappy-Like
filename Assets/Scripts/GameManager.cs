using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour, IService
{    
    [SerializeField] private GameState _currentState = GameState.PlayScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private Score _score;
    
    public UnityEvent <GameState> OnGameStateChanged;
    
    public enum GameState
    {
        PlayScreen,
        DeathScreen
    }

    public GameState CurrentState
    {
        get => _currentState;
        set
        {
            if (_currentState != value)
            {
                _currentState = value;
                Debug.Log("&&&&&&&&&&&&&&&&&&&&&&&&");
                //OnGameStateChanged?.Invoke(_currentState);
                //ScreenChanger();
            }
        }
    }

    private void Awake()
    {
        //ServiceLocator.Register(this);
        //Init();
    }

    public void Init()
    {
        ServiceLocator.Get<GameManager>();
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        ChangeState(GameState.PlayScreen);
    }

    public void ChangeState(GameState newState)
    {
        Debug.Log(newState);
        CurrentState = newState;
        OnGameStateChanged?.Invoke(CurrentState);
        ScreenChanger();        
    }

    private void ScreenChanger()
    {
        switch (CurrentState)
        {
            case GameState.PlayScreen:
                {
                    EnterPlayScreen();
                    break;
                }
                
            case GameState.DeathScreen:
                {
                    EnterDeathScreen();
                    break;
                }                
        }
    }

    private void EnterPlayScreen()
    {
        Time.timeScale = 1f;        
        Debug.Log("Entered Play Screen");
        Instantiate(_player);
        _score.ResetScore();
    }

    private void EnterDeathScreen()
    {
        Time.timeScale = 0f;
        Debug.Log("Entered Death Screen");
        _score.ShowScoreOnDeath();        
    }

    public void PlayerDied()
    {        
        Debug.Log("PlayerDIed");
        ChangeState(GameState.DeathScreen);
    }
    public void RestartGame()
    {
        ChangeState(GameState.PlayScreen);
        EnemyClear();
    }

    void EnemyClear()
    {
        EnemyDeath [] allEnemies = FindObjectsOfType<EnemyDeath>();
        foreach (EnemyDeath enemy in allEnemies)
        {            
            Destroy(enemy.gameObject);                       
        }
    }
}


