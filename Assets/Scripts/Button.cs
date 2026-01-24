using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Button : MonoBehaviour, IInteractable
{
    [Header("Identity Settings")]
    [SerializeField] private int buttonID;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;
    public void Interact()
    {
        Debug.Log($"Interact with {buttonID}");
        _signalBus.Fire(new GameSignal.InteractButton(buttonID));
    }
}
