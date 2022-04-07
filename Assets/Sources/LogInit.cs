using UnityEngine;

public class LogInit : MonoBehaviour
{
    [SerializeField] private NutInit _init;
    [SerializeField] private TextView _inertiaView;
    [SerializeField] private TextView _deltaView;

    private void OnEnable()
    {
        _init.Input.DeltaChanged += OnDeltaChanged;
    }

    private void OnDisable()
    {
        _init.Input.DeltaChanged -= OnDeltaChanged;
    }

    private void Update()
    {
        _inertiaView.UpdateText(_init.InertRotation.Acceleration);
    }

    private void OnAccelerationChanged(float value)
    {
        _inertiaView.UpdateText(value);
    }

    private void OnDeltaChanged(float value)
    {
        _deltaView.UpdateText(value);
    }
}