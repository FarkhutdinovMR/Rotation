using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private NutInit _nut;
    [SerializeField] private Caster _bolt;
    [SerializeField] private Caster _barrier;

    private void Update()
    {
        if (_barrier.IsCollision)
        {
            _nut.InertRotation.Stop();
            _nut.InertRotation.Accelerate(_barrier.ComputePenetration() / _nutSettings.MovePerRotate * _barrier.Direction());
        }
        else
        {
            if (_bolt.IsCollision)
                _nut.Input.Update();
        }

        _nut.Transformable.Rotate(_nut.InertRotation.Acceleration * Time.deltaTime);
        _nut.Presenter.Update();
    }
}