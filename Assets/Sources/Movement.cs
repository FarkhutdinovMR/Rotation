using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private NutInit _nut;
    [SerializeField] private Caster _bolt;
    [SerializeField] private Caster _obstacle;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _pushForce;

    private int _direction = 1;

    private void Update()
    {
        if (_rigidbody.useGravity)
            return;

        if (_obstacle.IsCollision)
            PreventPenetration();

        Move();
        _nut.Presenter.Update();
    }

    public void InvertDirection()
    {
        _direction *= -1;
    }

    public void Init()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = false;
        _collider.isTrigger = true;
    }

    private void PreventPenetration()
    {
        float depth = _obstacle.ComputePenetration();
        float angle = depth / _nutSettings.MovePerRotate;
        float delta = angle * _obstacle.Direction();

        _nut.InertRotation.Stop();
        _nut.InertRotation.Accelerate(delta);
    }

    private void Move()
    {
        float angle = _nut.InertRotation.Acceleration * Time.deltaTime;

        if (_bolt.IsCollision)
            RotateAtBolt(angle);
        else
            MoveInAir(angle);

        _nut.Transformable.Translate(angle * _nutSettings.MovePerRotate);
    }

    private void RotateAtBolt(float angle)
    {
        float delta = _nut.Input.Rotate;
        delta *= _nutSettings.RotateScale * _direction;
        _nut.InertRotation.Accelerate(delta);
        _nut.Transformable.Rotate(angle);
    }

    private void MoveInAir(float angle)
    {
        float delta = _nut.Input.Rotate;

        if (Mathf.Approximately(delta, 0) == false)
            Push(delta);

        if (_nut.InertRotation.Acceleration > 0)
            _nut.Transformable.Rotate(angle);
    }

    private void Push(float delta)
    {
        _nut.InertRotation.Stop();
        _rigidbody.useGravity = true;
        _collider.isTrigger = false;
        _rigidbody.AddForce(Vector3.right * delta * _pushForce, ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.up * delta, ForceMode.Impulse);
    }
}