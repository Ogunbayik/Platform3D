using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerUI : MonoBehaviour
{
    private PlayerInteract _interact;

    [Header("UI Settings")]
    [SerializeField] private Image _notificationImage;
    [Header("Transform Settings")]
    [SerializeField] private Vector3 _offsetPosition;

    [Inject]
    public void Construct(PlayerInteract interact) => _interact = interact;
    private void Awake() => ToggleNotificationImage(false);        

    private void OnEnable()
    {
        _interact.OnTargetInteractable += Interact_OnTargetInteractable;
        _interact.OnPlayerInteract += Interact_OnPlayerInteract;
    }
    private void OnDisable()
    {
        _interact.OnTargetInteractable -= Interact_OnTargetInteractable;
        _interact.OnPlayerInteract -= Interact_OnPlayerInteract;
    }
    private void Interact_OnTargetInteractable(Vector3 target, bool isActive)
    {
        var imagePosition = target + _offsetPosition;
        ToggleNotificationImage(isActive);
        SetNotificationPosition(imagePosition);
    }
    private void Interact_OnPlayerInteract() => ToggleNotificationImage(false);
    private void SetNotificationPosition(Vector3 position) => _notificationImage.transform.position = position;
    private void ToggleNotificationImage(bool isActive) => _notificationImage.gameObject.SetActive(isActive);
}
