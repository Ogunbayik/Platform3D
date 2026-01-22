using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private float gravity = -20f;

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
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Yere tam yapýþmasý için ufak bir negatif deðer
        }

        CalculateMovementVelocity();


        var isJumpPressed = _input.IsJumpPressed();
        if (_characterController.isGrounded && isJumpPressed)
        {
            _velocity.y = Mathf.Sqrt(_data.JumpHeight * -2f * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
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
