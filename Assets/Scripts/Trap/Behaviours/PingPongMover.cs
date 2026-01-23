using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMover : MoverBase
{
    [Header("Position Settings")]
    [SerializeField] private Vector3[] _movementOffset;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private int _moveIndex;
    protected override void Start()
    {
        _moveIndex = 0;
        _startPosition = transform.position + _movementOffset[_moveIndex];
        _targetPosition = _startPosition;
    }
    public override void HandleMovement()
    {
        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
        {
            transform.position = _targetPosition;
            SetMovementPosition();
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
    }
    private void SetMovementPosition()
    {
        if(_moveIndex < _movementOffset.Length - 1)
        {
            _moveIndex++;
            var nextPosition = transform.position + _movementOffset[_moveIndex];
            _targetPosition = nextPosition;
        }
        else
        {
            _moveIndex = 0;
            _targetPosition = _startPosition;
        }
    }
}
