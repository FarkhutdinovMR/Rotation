using System;
using Models;
using UnityEngine.InputSystem;

public class NutInputRouter
{
    private readonly NutInput _input;
    private readonly InertRotation _inertRotation;
    private readonly NutSettings _nutSettings;

    public event Action<float> DeltaChanged;

    public NutInputRouter(InertRotation inertRotation, NutSettings nutSettings)
    {
        if (inertRotation == null)
            throw new ArgumentNullException(nameof(inertRotation));

        _inertRotation = inertRotation;
        _nutSettings = nutSettings;
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
        Inertia(delta);

        DeltaChanged?.Invoke(delta);
    }

    private void Inertia(float delta)
    {
        if (GrabStarted())
        {
            _inertRotation.Stop();
            _inertRotation.Accelerate(delta * _nutSettings.RotateScale);
        }
    }

    private bool GrabStarted()
    {
        return _input.Nut.Grab.phase == InputActionPhase.Started;
    }
}