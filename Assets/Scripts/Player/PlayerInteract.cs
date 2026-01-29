using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInteract : MonoBehaviour
{
    private IInpuService _input;

    public event Action<Vector3,bool> OnTargetInteractable;
    public event Action OnPlayerInteract;

    [Inject]
    public void Construct(IInpuService input) => _input = input; 

    [Header("Visual Settings")]
    [SerializeField] private Transform _playerVisual;
    void Update()
    {
        Ray ray = new Ray(_playerVisual.position, _playerVisual.forward);
        if(Physics.Raycast(ray,out RaycastHit hitInfo, Const.PlayerConstant.INTERACT_DISTANCE))
        {
            if (hitInfo.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if (interactable.CanInteract)
                    OnTargetInteractable?.Invoke(hitInfo.transform.position, true);

                if (_input.IsInteractPressed())
                {
                    interactable.Interact();
                    OnPlayerInteract?.Invoke();
                }
            }
        }
        else
        {
            OnTargetInteractable?.Invoke(Vector3.zero, false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_playerVisual.position, _playerVisual.forward * Const.PlayerConstant.INTERACT_DISTANCE);
    }
}
