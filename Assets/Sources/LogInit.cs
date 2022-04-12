using UnityEngine;

public class LogInit : MonoBehaviour
{
    [SerializeField] private NutInit _init;
    [SerializeField] private TextView _inertiaView;
    [SerializeField] private TextView _deltaView;

    private void Update()
    {
        _inertiaView.UpdateText(_init.InertRotation.Acceleration);
        _deltaView.UpdateText(_init.Input.Rotate);
    }
}