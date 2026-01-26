using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    protected Rigidbody _rb;
    public virtual void Awake() => _rb = GetComponent<Rigidbody>();
    public virtual void Start() => DeactivateGravity();
    private void DeactivateGravity() => _rb.useGravity = false;
}
