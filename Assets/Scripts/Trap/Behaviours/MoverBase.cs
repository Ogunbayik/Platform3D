using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoverBase : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] protected float _movementSpeed;

    protected virtual void Start() { }
    public abstract void HandleMovement();
    protected virtual void FixedUpdate() => HandleMovement();
}
