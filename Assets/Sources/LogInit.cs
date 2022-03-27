using UnityEngine;

public class LogInit : MonoBehaviour
{
    [SerializeField] private Init _init;
    [SerializeField] private TextView _inertiaView;

    private void OnEnable()
    {
        _init.Inertia.AccelerationChanged += OnAccelerationChanged;
    }

    private void OnDisable()
    {
        _init.Inertia.AccelerationChanged -= OnAccelerationChanged;
    }

    private void OnAccelerationChanged(float value)
    {
        _inertiaView.UpdateText(value);
    }
}