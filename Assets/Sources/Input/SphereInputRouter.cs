using UnityEngine.InputSystem;
using Models;
using System;

public class SphereInputRouter
{
    private readonly SphereInput _input;
    private readonly IRotation _rotation;

    public SphereInputRouter(IRotation rotation)
    {
        if (rotation == null)
            throw new ArgumentNullException(nameof(rotation));

        _rotation = rotation;
        _input = new SphereInput();
    }

    public void OnEnable()
    {
        _input.Enable();
        _input.Sphere.Rotate.started += OnRotate;
    }

    public void OnDisable()
    {
        _input.Disable();
        _input.Sphere.Rotate.started -= OnRotate;
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        Rotate(context.ReadValue<float>());
    }

    private void Rotate(float direction)
    {
        _rotation.Rotate(direction);
    }
}