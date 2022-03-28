using UnityEngine;

public class LogInit : MonoBehaviour
{
    [SerializeField] private Init _init;
    [SerializeField] private TextView _inertiaView;
    [SerializeField] private TextView _deltaView;

    private void OnEnable()
    {
        _init.InertRotation.AccelerationChanged += OnAccelerationChanged;
        _init.Input.DeltaChanged += OnDeltaChanged;
    }

    private void OnDisable()
    {
        _init.InertRotation.AccelerationChanged -= OnAccelerationChanged;
        _init.Input.DeltaChanged -= OnDeltaChanged;
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