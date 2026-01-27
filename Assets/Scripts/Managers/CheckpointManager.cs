using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 _currentCheckpointPosition;

    [Header("Spawn Settings")]
    [SerializeField] private Vector3 spawnOffset;
    [SerializeField] private Transform _startPosition;
    public Vector3 CheckpointPosition => _currentCheckpointPosition;
    private void Awake() => _currentCheckpointPosition = _startPosition.position;
    public void UpdateCheckpoint(Vector3 checkpoint) => _currentCheckpointPosition = checkpoint;
    
}
