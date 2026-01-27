using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CrumblingPlatform : BasePlatform
{
    public event Action OnPlayerTriggered;

    [Header("Shake Settings")]
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeStrength;
    [SerializeField] private int _vibratoCount;
    [SerializeField] private float _randomness;
    [Header("Crumble Settings")]
    [SerializeField] private float _crumbleOffset;

    private bool _isFalling = false;
    public override void Awake() => base.Awake();
    public override void Start() => base.Start();
    private void OnEnable() => OnPlayerTriggered += CrumblingPlatform_OnPlayerTriggered;
    private void OnDisable() => OnPlayerTriggered -= CrumblingPlatform_OnPlayerTriggered;
    private void CrumblingPlatform_OnPlayerTriggered() => HandleFallSequence();
    private void HandleFallSequence()
    {
        DOTween.Kill(transform);
        var targetCurmbleY = transform.position.y - _crumbleOffset;

        Sequence fallSequence = DOTween.Sequence();
        fallSequence.AppendCallback(() => transform.DOShakePosition(_shakeDuration, _shakeStrength, _vibratoCount, _randomness));
        fallSequence.JoinCallback(() => transform.DOMoveY(targetCurmbleY, _shakeDuration).SetEase(Ease.InQuad));
        fallSequence.AppendInterval(_shakeDuration * 0.9f);
        fallSequence.AppendCallback(() => ActivateGravity());
    }
    private void ActivateGravity()
    {
        _rb.useGravity = true;
        _rb.isKinematic = false;
    }
    public void TriggerFall()
    {
        if (_isFalling)
            return;

        _isFalling = true;
        OnPlayerTriggered?.Invoke();
    }
}
