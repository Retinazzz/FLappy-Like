using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLoader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private EnemyDeath _enemy;
    [SerializeField] private GameManager _gameManager1;
    private GameManager _gameManager;
    private UI _ui;

    private void Awake()
    {
        //_gameManager = new GameManager();
        //_ui = new UI();
        RegisterServices();
        Init();        
    }

    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        Debug.Log("REGISTEER");
        ServiceLocator.Register(_player);
        ServiceLocator.Register(_gameManager1);
        ServiceLocator.Register(_ui);
        ServiceLocator.Register(_enemy);
    }

    private void Init()
    {
        //_player.Init();
        //_gameManager.Init();
        //_ui.Init();
        //_enemy.Init();
    }
}
