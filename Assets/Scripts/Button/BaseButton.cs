using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseButton : MonoBehaviour, IInteractable
{
    [Header("Identity Settings")]
    [Tooltip("You need to synchronize the IDs for the Platform and Button")]
    [SerializeField] protected int _buttonID;

    private SignalBus _signalBus;

    protected bool _canInteract = true;
    public bool CanInteract => _canInteract;
    public int ID => _buttonID;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    public virtual void Interact()
    {
        _signalBus.Fire(new GameSignal.InteractedSignal(this));
    }

}
