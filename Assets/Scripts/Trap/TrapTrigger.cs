using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrapTrigger : MonoBehaviour
{
    [Header("Trap Settings")]
    [SerializeField] private int _trapID;
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Const.Tag.PLAYER_TAG))
        {
            Debug.Log("Triggered");
            _signalBus.Fire(new GameSignal.TrapTriggeredSignal(_trapID));
        }
    }
}
