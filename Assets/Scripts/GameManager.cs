using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{    
    [SerializeField] private GameState _currentState = GameState.PlayScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private Score _score;
    
    public UnityEvent<GameState> OnGameStateChanged;

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
                OnGameStateChanged?.Invoke(_currentState);
                ScreenChanger();
            }
        }
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
        CurrentState = newState;
    }
    private void ScreenChanger()
    {
        switch (_currentState)
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


