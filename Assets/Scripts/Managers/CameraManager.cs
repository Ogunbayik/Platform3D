using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Zenject;

public class CameraManager : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    [Header("Game Cameras")]
    [SerializeField] private CinemachineVirtualCamera _gameCamera;
    [SerializeField] private CinemachineVirtualCamera _deadCamera;
    private void OnEnable()
    {
        _signalBus.Subscribe<GameSignal.PlayerDiedSignal>(OnPlayerDied);
        _signalBus.Subscribe<GameSignal.PlayerRespawnSignal>(OnPlayerRespawn);
        
    }
    private void OnDisable()
    {
        _signalBus.Unsubscribe<GameSignal.PlayerDiedSignal>(OnPlayerDied);
        _signalBus.Unsubscribe<GameSignal.PlayerRespawnSignal>(OnPlayerRespawn);
    }
    private void OnPlayerDied() => SwitchToDeadCamera();
    private void OnPlayerRespawn() => SwitchToGameCamera();
    private void SwitchToDeadCamera()
    {
        _gameCamera.Priority = Const.CameraPriority.INACTIVE_PRIORITY;
        _deadCamera.Priority = Const.CameraPriority.ACTIVE_PRIORITY;
    }
    private void SwitchToGameCamera()
    {
        _gameCamera.Priority = Const.CameraPriority.ACTIVE_PRIORITY;
        _deadCamera.Priority = Const.CameraPriority.INACTIVE_PRIORITY;
    }
}
