using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : BasePlatform
{
    [Header("Fall Settings")]
    [SerializeField] private float _fallTime;

    private float _timer;

    private bool _isFalling = false;
    public override void Awake() => base.Awake();
    public override void Start() => base.Start();
    void Update() => HandleFallingCountdown();
    private void HandleFallingCountdown()
    {
        if (_isFalling)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _timer = 0;
                ActivateGravity();
            }
        }
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
        _timer = _fallTime;
    }

}
