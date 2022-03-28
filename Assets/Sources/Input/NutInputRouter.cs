using System;
using Models;
using UnityEngine;
using UnityEngine.InputSystem;

public class NutInputRouter
{
    private readonly NutInput _input;
    private readonly IRotation _rotation;
    private readonly InertRotation _inertRotation;

    public event Action<float> DeltaChanged;

    public NutInputRouter(InertRotation inertRotation, IRotation rotation)
    {
        if (inertRotation == null)
            throw new ArgumentNullException(nameof(inertRotation));

        if (rotation == null)
            throw new ArgumentNullException(nameof(rotation));

        _inertRotation = inertRotation;
        _rotation = rotation;
        _input = new NutInput();
    }

    public void OnEnable()
    {
        _input.Enable();
    }

    public void OnDisable()
    {
        _input.Disable();
    }

    public void Update()
    {
        float delta = _input.Nut.Rotate.ReadValue<float>();
        float angle;

        if (GrabStarted())
            angle = _inertRotation.Accelerate(delta);
        else
            angle = _inertRotation.Slowdown();

        _rotation.Rotate(angle * Time.deltaTime);

        DeltaChanged?.Invoke(delta);
    }

    private bool GrabStarted()
    {
        return _input.Nut.Grab.phase == InputActionPhase.Started;
    }
}