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
    private SignalBus _signalBus;

    private Vector3 _movementDirection;
    private Vector3 _velocity;

    [Inject]
    public void Construct(IInpuService input,PlayerDataSO data, SignalBus signalBus)
    {
        _input = input;
        _data = data;
        _signalBus = signalBus;
    }
    private void Awake() => _characterController = GetComponent<CharacterController>();
    private void OnEnable()
    {
        _signalBus.Subscribe<GameSignal.DeadTriggerSignal>(HandleDeadSignal);
        _signalBus.Subscribe<GameSignal.PlayerRespawnSignal>(HandleRespawnSignal);
    }
    private void OnDisable()
    {
        _signalBus.Unsubscribe<GameSignal.DeadTriggerSignal>(HandleDeadSignal);
        _signalBus.Unsubscribe<GameSignal.PlayerRespawnSignal>(HandleRespawnSignal);
    }
    private void HandleDeadSignal(GameSignal.DeadTriggerSignal signal) => SetPlayerController(false);
    private void HandleRespawnSignal(GameSignal.PlayerRespawnSignal signal) => SetPlayerController(true);
    private void SetPlayerController(bool isActive)
    {
        _characterController.enabled = isActive;
    }
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
            _playerVisual.transform.rotation = Quaternion.Slerp(_playerVisual.transform.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
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
}
