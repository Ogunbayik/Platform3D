using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] protected GameObject _visualTransform;
    protected Rigidbody _rb;
    protected BoxCollider _collider;
    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }
    public virtual void Start() => InitialSettings();
    private void InitialSettings()
    {
        _rb.useGravity = false;
        _rb.isKinematic = true;
        _collider.size = _visualTransform.transform.localScale;
    }
}
