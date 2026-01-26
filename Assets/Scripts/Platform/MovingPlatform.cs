using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(MoverBase))]
public class MovingPlatform : BasePlatform
{
    [Header("Identity Settings")]
    [Tooltip("You need to synchronize the IDs for the Platform and Button")]
    [SerializeField] private int _platformID;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private MoverBase _mover;

    public override void Awake()
    {
        base.Awake();
        _mover = GetComponent<MoverBase>();
    }
    public override void Start() => base.Start();
    private void OnEnable() => _signalBus.Subscribe<GameSignal.InteractedSignal>(ActivateMove);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.InteractedSignal>(ActivateMove);
    private void ActivateMove(GameSignal.InteractedSignal signal)
    {
        if (signal.Interactable is BaseButton button)
        {
            if (_platformID == button.ID)
            {
                if (button is ExplicitButton explicitButton && _mover is StraightMover straight)
                    straight.SetMovementDirection(explicitButton.MoveDirection);

                _mover.enabled = true;
            }
        }
    }
}
