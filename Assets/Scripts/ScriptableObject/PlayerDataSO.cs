using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "SO/Data/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight;
    [Header("Gravity Settings")]
    [SerializeField] private float _gravity;

    public float MovementSpeed => _movementSpeed;
    public float JumpHeight => _jumpHeight;
    public float Gravity => _gravity;
}
