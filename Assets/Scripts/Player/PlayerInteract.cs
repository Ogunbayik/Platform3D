using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInteract : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] private Transform _playerVisual;
    void Update()
    {
        Ray ray = new Ray(_playerVisual.position, _playerVisual.forward);
        if(Physics.Raycast(ray,out RaycastHit hitInfo, Const.PlayerConstant.INTERACT_DISTANCE))
        {
            if (hitInfo.transform.TryGetComponent<IInteractable>(out IInteractable interactable) && Input.GetKeyDown(KeyCode.E))
                interactable.Interact();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_playerVisual.position, _playerVisual.forward * Const.PlayerConstant.INTERACT_DISTANCE);
    }
}
