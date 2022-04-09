using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private NutInit _nut;
    [SerializeField] private BoltCast _boltCast;

    private void Update()
    {
        if (_boltCast.InAir == false)
            _nut.Input.Update();

        _nut.Transformable.Rotate(_nut.InertRotation.Acceleration * Time.deltaTime);
        _nut.Presenter.Update();
    }
}