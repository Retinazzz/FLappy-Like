using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSystem : IService
{
    event Action FireClicked;
    event Action JumpClicked;
    void PressJump ();
    void PressShoot ();
}
public class InputSystem :  IInputSystem , IService
{
    public event Action FireClicked;
    public event Action JumpClicked;
    
   public void PressJump ()
    {
        JumpClicked?.Invoke();        
    }
    public void PressShoot ()
    {
        FireClicked?.Invoke();
    }
   
    public InputSystem ()
    {

    }
}
