using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrapPlatform : BasePlatform
{
    [Header("Identity Settings")]
    [Tooltip("You need to synchronize the IDs for the Platform and Button")]
    [SerializeField] private int _platformID;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    public override void Awake() => base.Awake();
    public override void Start() => base.Start();
    private void OnEnable() => _signalBus.Subscribe<GameSignal.TrapTriggeredSignal>(ActivateTrap);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.TrapTriggeredSignal>(ActivateTrap);
    private void ActivateTrap(GameSignal.TrapTriggeredSignal signal)
    {
        if (_platformID == signal.TrapID)
            ActivateGravity();
    }
    private void ActivateGravity()
    {
        _rb.useGravity = true;
        _rb.isKinematic = false;
    }
}
