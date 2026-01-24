using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour
{
    [Header("Identity Settings")]
    [SerializeField] private int _platformID;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private MoverBase _mover;

    private void Awake()
    {
        _mover = GetComponent<MoverBase>();
    }
    private void OnEnable()
    {
        _signalBus.Subscribe<GameSignal.InteractButton>(ActivateMove);
    }
    private void OnDisable()
    {
        _signalBus.Unsubscribe<GameSignal.InteractButton>(ActivateMove);
    }

    private void ActivateMove(GameSignal.InteractButton signal)
    {
        if (_platformID == signal.ButtonID)
            _mover.enabled = true;
    }
}
