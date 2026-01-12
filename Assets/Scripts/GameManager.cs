using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameState _currentState = GameState.PlayScreen;
    [SerializeField] private GameObject _player;
    
    
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
    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start ()
    {
        StartGame();
    }

    private void StartGame ()
    {
        ChangeState(GameState.PlayScreen);
    }
    public void ChangeState (GameState newState)
    {
        CurrentState = newState;
    }
    private void ScreenChanger ()
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

    private void EnterPlayScreen ()
    {
        Time.timeScale = 1f;        
        Debug.Log("Entered Play Screen");
        Instantiate(_player);
        Score.Instance.ResetScore();
    }

    private void EnterDeathScreen ()
    {
        Time.timeScale = 0f;
        Debug.Log("Entered Death Screen");
        Score.Instance.ShowScoreOnDeath();
        
    }

    public void PlayerDied ()
    {
        ChangeState(GameState.DeathScreen);
    }

    public void RestartGame ()
    {
        ChangeState(GameState.PlayScreen);
        EnemyClear();
    }

    void EnemyClear ()
    {
        EnemyDeath [] allEnemies = FindObjectsOfType<EnemyDeath>();
        foreach (EnemyDeath enemy in allEnemies)
        {            
            Destroy(enemy.gameObject);                       
        }
    }
}


