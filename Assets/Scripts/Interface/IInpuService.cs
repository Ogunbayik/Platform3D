using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInpuService 
{
    float GetHorizontal();
    float GetVertical();
    bool IsJumpPressed();
    bool IsInteractPressed();
}
