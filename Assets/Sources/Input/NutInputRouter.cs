using System;
using Models;
using UnityEngine;
using UnityEngine.InputSystem;

public class NutInputRouter
{
    private readonly NutInput _input;
    private readonly IRotation _rotation;
    private readonly InertRotation _inertRotation;
    private readonly float _unitPerSecond;

    public event Action<float> DeltaChanged;

    public NutInputRouter(InertRotation inertRotation, IRotation rotation, float unitPerSecond)
    {
        if (inertRotation == null)
            throw new ArgumentNullException(nameof(inertRotation));

        if (rotation == null)
            throw new ArgumentNullException(nameof(rotation));

        if (unitPerSecond <= 0)
            throw new ArgumentOutOfRangeException(nameof(unitPerSecond), "Should be more than 0.");

        _inertRotation = inertRotation;
        _rotation = rotation;
        _unitPerSecond = unitPerSecond;
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
        float delta = Input();
        Inertia(delta);

        _rotation.Rotate(_inertRotation.Acceleration * Time.deltaTime);
        DeltaChanged?.Invoke(delta);
    }

    private float Input()
    {
        return _input.Nut.Rotate.ReadValue<float>();
    }

    private void Inertia(float delta)
    {
        if (GrabStarted())
        {
            _inertRotation.Stop();
            _inertRotation.Accelerate(delta * _unitPerSecond);
        }
    }

    private bool GrabStarted()
    {
        return _input.Nut.Grab.phase == InputActionPhase.Started;
    }
}