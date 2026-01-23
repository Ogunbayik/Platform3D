using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallableTrap : TrapBase
{
    private Rigidbody _rb;
    public override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody>();
        ActivateGravity(false);
    }
    private void OnEnable() => _signalBus.Subscribe<GameSignal.TrapTriggeredSignal>(ActivateTrap);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.TrapTriggeredSignal>(ActivateTrap);

    public override void ActivateTrap(GameSignal.TrapTriggeredSignal signal)
    {
        if (_trapID == signal.TrapID)
            ActivateGravity(true);
    }

    private void ActivateGravity(bool isActive)
    {
        _rb.isKinematic = !isActive;
        _rb.useGravity = isActive;
    }
}
