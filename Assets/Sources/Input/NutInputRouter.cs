using UnityEngine.InputSystem;

public class NutInputRouter
{
    private readonly NutInput _input;

    public float Rotate => _input.Nut.Grab.phase == InputActionPhase.Started ? _input.Nut.Rotate.ReadValue<float>() : 0;

    public NutInputRouter()
    {
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
}