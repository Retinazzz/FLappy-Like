using UnityEngine;
using static GameManager;

public class UI: MonoBehaviour , IService
{    
    [SerializeField] private GameObject _playScreenPanel;
    [SerializeField] private GameObject _deathScreenPanel;
    //private GameManager _gameManager;    

    public void Init()
    {
        ServiceLocator.Get<UI>();        
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        Debug.Log("1st awakeninn");
        if (ServiceLocator.Get<GameManager>() == null)
        {
            Debug.LogError("GameManager не найден!");
            return;
        }
        // Подписываемся
        //ServiceLocator.Get<GameManager>().OnGameStateChanged.AddListener(StateChanged);
        ServiceLocator.Get<GameManager>().OnGameStateChanged.AddListener(StateChanged);
        Debug.Log("___________________");

        //StateChanged(ServiceLocator.Get<GameManager>().CurrentState);
        Debug.Log(ServiceLocator.Get<GameManager>().CurrentState + "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        //ServiceLocator.Current.Get<_>();
    }

    public void StateChanged(GameState newState)
    {
        //Debug.Log(newState + "APAPPAPAPAPAPPA");
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