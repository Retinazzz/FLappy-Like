using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] private Rigidbody2D _jumper;
    [SerializeField] private float _forceOnJump = 0.3f;    

    private Vector2 _posToJump;
    private IInputSystem  _inputSystem;    

    private void Awake ()
    {       
        _inputSystem = new InputSystem();
        Init(_inputSystem);
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            _inputSystem.PressJump();            
        }          
    }

    public void Init (IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.JumpClicked += OnJumpButtonClicked;
    }

    public void Jump ()
    {
        _jumper.AddForce(_forceOnJump * Vector2.up);
    }
    private void OnJumpButtonClicked ()
    {
        Debug.Log("jump");
        Jump();
       
    }
    void OnDestroy ()
    {        
        if (_inputSystem != null)
        {
            _inputSystem.JumpClicked -= OnJumpButtonClicked;
        }
    }
    
    

}
