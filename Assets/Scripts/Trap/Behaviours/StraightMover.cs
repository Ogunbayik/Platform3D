using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMover : MoverBase
{
    [Header("Direction Settings")]
    [SerializeField] private Vector3 _movementDirection;
    public override void HandleMovement() => transform.Translate(_movementDirection * _movementSpeed * Time.deltaTime);
}
