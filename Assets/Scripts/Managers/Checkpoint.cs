using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Checkpoint : MonoBehaviour, IInteractable
{
    private CheckpointManager _checkpointManager;

    [Inject]
    public void Construct(CheckpointManager manager) => _checkpointManager = manager;
    public void Interact() => _checkpointManager.UpdateCheckpoint(transform.position);
}
