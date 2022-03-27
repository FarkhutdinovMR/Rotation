using System;
using Models;
using UnityEngine.InputSystem;

public class SphereInputRouter
{
    private readonly SphereInput _input;
    private readonly IRotation _rotation;
    private readonly Inertia _inertia;

    public SphereInputRouter(IRotation rotation, Inertia inertia)
    {
        if (rotation == null)
            throw new ArgumentNullException(nameof(rotation));

        _rotation = rotation;
        _inertia = inertia;
        _input = new SphereInput();
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
        if (GrabStarted())
        {
            float direction = _input.Sphere.Rotate.ReadValue<float>();
            _rotation.Rotate(direction);
            _inertia.Update(direction);
        }
        else
        {
            _inertia.Rotate();
        }
    }

    private bool GrabStarted()
    {
        return _input.Sphere.Grab.phase == InputActionPhase.Started;
    }
}