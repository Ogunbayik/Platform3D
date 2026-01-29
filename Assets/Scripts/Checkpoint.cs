using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Checkpoint : MonoBehaviour, IInteractable
{
    private SignalBus _signalBus;
    private bool _canInteract = true;
    public bool CanInteract => _canInteract;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;
    public void Interact()
    {
        _signalBus.Fire(new GameSignal.PlayerReachCheckpointSignal(this.transform));
        _canInteract = false;
    }
}
