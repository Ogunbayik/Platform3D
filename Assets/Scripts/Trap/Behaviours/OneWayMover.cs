using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMover : MoverBase
{
    [Header("Position Settings")]
    [SerializeField] private Vector3 _desiredPosition;

    private Vector3 _targetPosition;
    protected override void Start() => _targetPosition = transform.position + _desiredPosition;
    public override void HandleMovement() => transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed *  Time.deltaTime);
}
