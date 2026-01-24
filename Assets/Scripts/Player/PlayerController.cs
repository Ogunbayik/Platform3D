using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] private GameObject _playerVisual;

    private CharacterController _characterController;

    private IInpuService _input;
    private PlayerDataSO _data;

    private Vector3 _movementDirection;
    private Vector3 _velocity;

    [Inject]
    public void Construct(IInpuService input,PlayerDataSO data)
    {
        _input = input;
        _data = data;
    }
    private void Awake() => _characterController = GetComponent<CharacterController>();
    private void Update()
    {
        HandleMovement();

        if (_velocity.sqrMagnitude > 0.1f)
            HandleRotation(_velocity);

        if (!_characterController.isGrounded)
            transform.parent = null;
    }
    private void HandleMovement()
    {
        if (_characterController.isGrounded && _velocity.y < 0)
            _velocity.y = Const.GameConstant.GRAVITY_FACTOR;

        CalculateMovementVelocity();

        HandleJump();
        _characterController.Move(_velocity * Time.deltaTime);
    }
    private void HandleJump()
    {
        var isJumpPressed = _input.IsJumpPressed();
        if (_characterController.isGrounded && isJumpPressed)
            _velocity.y = Mathf.Sqrt(_data.JumpHeight * Const.GameConstant.GRAVITY_FACTOR * Const.GameConstant.GRAVITY);

        _velocity.y += Const.GameConstant.GRAVITY * Time.deltaTime;
    }
    private void HandleRotation(Vector3 direction)
    {
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_movementDirection);
            _playerVisual.transform.rotation = Quaternion.Slerp(_playerVisual.transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
    private void CalculateMovementVelocity()
    {
        var horizontal = _input.GetHorizontal();
        var vertical = _input.GetVertical();

        _movementDirection.Set(horizontal, 0f, vertical);

        if (_movementDirection.sqrMagnitude >= 1f)
            _movementDirection.Normalize();

        _velocity.x = _movementDirection.x * _data.MovementSpeed;
        _velocity.z = _movementDirection.z * _data.MovementSpeed;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(Const.Tag.MOVING_PLATFORM_TAG))
            transform.parent = hit.transform;
    }
}
