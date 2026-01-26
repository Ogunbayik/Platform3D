using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ExplicitButton : BaseButton
{
    [Header("Direction Settings")]
    [SerializeField] private Vector3 _moveDirection;

    public Vector3 MoveDirection => _moveDirection;
}
