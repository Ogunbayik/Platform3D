using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayMover : MoverBase
{
    [Header("Position Settings")]
    [SerializeField] private Vector3 _movementOffset;

    private Vector3 _desiredPosition;
    protected override void Start() => _desiredPosition = transform.position + _movementOffset;
    public override void HandleMovement() => transform.position = Vector3.MoveTowards(transform.position, _desiredPosition, _movementSpeed *  Time.deltaTime);
}
