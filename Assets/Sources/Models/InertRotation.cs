using UnityEngine;

namespace Models
{
    public class InertRotation
    {
        private readonly float _rotateMaxSpeed;
        private const float StopSpeed = 0;

        private float _acceleration;
        private int _direction = 1;

        public float Acceleration => _acceleration;

        public InertRotation(float rotateMaxSpeed)
        {
            _rotateMaxSpeed = rotateMaxSpeed;
        }

        public void Accelerate(float delta)
        {
            _acceleration += delta * _direction;
            _acceleration = Mathf.Clamp(_acceleration, -_rotateMaxSpeed, _rotateMaxSpeed);
        }

        public void Slowdown(float maxDelta)
        {
            _acceleration = Mathf.MoveTowards(_acceleration, StopSpeed, maxDelta);
        }

        public void Stop()
        {
            _acceleration = StopSpeed;
        }

        public void InvertDirection()
        {
            _direction *= -1;
        }
    }
}