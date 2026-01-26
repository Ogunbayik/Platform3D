using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IInpuService
{
    public float GetHorizontal() => Input.GetAxis(Const.PlayerInput.HORIZONTAL_INPUT);
    public float GetVertical() => Input.GetAxis(Const.PlayerInput.VERTICAL_INPUT);
    public bool IsJumpPressed() => Input.GetKeyDown(KeyCode.Space);
    public bool IsInteractPressed() => Input.GetKeyDown(KeyCode.E);
    
}
