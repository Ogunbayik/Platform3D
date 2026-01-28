using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class NotificationFeedView : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _notificationText;
    [Header("Animation Settings")]
    [Min(0f)]
    [SerializeField] private float _fadeDuration;
    [Min(0f)]
    [SerializeField] private float _displayDuration;

    private void Start() => HideNotification();
    private void OnEnable() => _signalBus.Subscribe<GameSignal.PlayerReachCheckpointSignal>(OnPlayerReachCheckpoint);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.PlayerReachCheckpointSignal>(OnPlayerReachCheckpoint);
    private void OnPlayerReachCheckpoint() => HandleCheckpointSequence();
    private void HandleCheckpointSequence()
    {
        _notificationText.DOKill();

        var checkpointSequence = DOTween.Sequence();

        checkpointSequence.AppendCallback(() => ShowNotificationText());
        checkpointSequence.Append(_notificationText.DOFade(Const.NotificationAlpha.ACTIVE_ALPHA, _fadeDuration));
        checkpointSequence.AppendInterval(_displayDuration);
        checkpointSequence.Append(_notificationText.DOFade(Const.NotificationAlpha.INACTIVE_ALPHA, _fadeDuration));
        checkpointSequence.AppendCallback(() => HideNotification());
    }
    private void ShowNotificationText() => _notificationText.gameObject.SetActive(true);
    private void HideNotification()
    {
        _notificationText.alpha = 0f;
        _notificationText.gameObject.SetActive(false);
    }

}
