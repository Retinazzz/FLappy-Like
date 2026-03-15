using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLoader : MonoBehaviour
{    
    [SerializeField] private EnemyDeath _enemy;
    [SerializeField] private GameManager _gameManager1;
    [SerializeField] private PlayerDeath _player;    
    private GameManager _gameManager;
    private UI _ui;
    
    private void Awake()
    {        
        RegisterServices();
        Init();        
    }

    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        IInputSystem InputSystem = new InputSystem();
        ServiceLocator.Register<IInputSystem>(InputSystem);
        ServiceLocator.Register(_gameManager1);        
        ServiceLocator.Register(_player);
        ServiceLocator.Register(_ui);
        ServiceLocator.Register(_enemy);        
    }

    private void Init()
    {
        //_player.Init();
        //_gameManager.Init();
        //_ui.Init();
        //_enemy.Init();
        //_inputSystem.Init();
    }
}
