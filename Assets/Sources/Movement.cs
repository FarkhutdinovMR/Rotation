using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private NutInit _nut;
    [SerializeField] private Rigidbody _rigidbody;

    private bool _inAir;

    public bool InAir => _inAir;

    private void Update()
    {
        if (_inAir == false)
            _nut.Input.Update();

        _nut.Transformable.Rotate(_nut.InertRotation.Acceleration);
        _nut.Presenter.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bolt bolt))
            _inAir = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Bolt bolt))
            _inAir = true;
    }
}