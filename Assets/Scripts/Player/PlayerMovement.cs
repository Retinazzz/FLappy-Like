using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour , IDamagable , IService
{    
    [SerializeField] private Rigidbody2D _jumper;
    [SerializeField] private float _forceOnJump = 0.3f;
    private Vector2 _posToJump;
    private IInputSystem  _inputSystem;    

    private void Start()
    {        
        Init();
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            _inputSystem.PressJump();            
        }          
    }

    public void Init()
    {
        _inputSystem = ServiceLocator.Get<IInputSystem>();
        _inputSystem.JumpClicked += OnJumpButtonClicked;
    }

    public void Jump()
    {
        _jumper.AddForce(_forceOnJump * Vector2.up);
    }

    private void OnJumpButtonClicked()
    {
        Debug.Log("jump");
        Jump();       
    }

    private void OnDestroy()
    {        
        if (_inputSystem != null)
        {
            _inputSystem.JumpClicked -= OnJumpButtonClicked;
        }
    }
}
