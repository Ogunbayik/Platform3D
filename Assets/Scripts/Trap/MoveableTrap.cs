using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoverBase))]
public class MoveableTrap : TrapBase
{
    private MoverBase _mover;

    public override void Awake()
    {
        base.Awake();
        _mover = GetComponent<MoverBase>();
        ActiveteMover(false);
    }
    private void OnEnable()
    {
        _signalBus.Subscribe<GameSignal.TrapTriggeredSignal>(ActivateTrap);
    }
    private void OnDisable()
    {
        _signalBus.Unsubscribe<GameSignal.TrapTriggeredSignal>(ActivateTrap);
    }
    public override void ActivateTrap(GameSignal.TrapTriggeredSignal signal)
    {
        if (_trapID == signal.TrapID)
            ActiveteMover(true);
    }
    private void ActiveteMover(bool isActive) => _mover.enabled = isActive;
}
