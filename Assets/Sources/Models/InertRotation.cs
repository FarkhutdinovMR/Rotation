using UnityEngine;

namespace Models
{
    public class InertRotation
    {
        private readonly NutSettings _nutSettings;
        private const float StopSpeed = 0;

        private float _acceleration;
        private int _direction = 1;

        public float Acceleration => _acceleration;

        public InertRotation(NutSettings nutSettings)
        {
            _nutSettings = nutSettings;
        }

        public void Accelerate(float delta)
        {
            _acceleration += delta * _direction;
            _acceleration = Mathf.Clamp(_acceleration, -_nutSettings.MaxAngularSpeed, _nutSettings.MaxAngularSpeed);
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