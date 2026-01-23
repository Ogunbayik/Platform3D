using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class TrapBase : MonoBehaviour
{
    [Header("Trap Settings")]
    [SerializeField] protected int _trapID;

    protected SignalBus _signalBus;
    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    public virtual void Awake() { }
    public abstract void ActivateTrap(GameSignal.TrapTriggeredSignal signal);
}
