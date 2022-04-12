using UnityEngine;

namespace Models
{
    public class Inertia
    {
        private readonly NutSettings _nutSettings;
        private const float StopSpeed = 0;

        private float _acceleration;

        public float Acceleration => _acceleration;

        public Inertia(NutSettings nutSettings)
        {
            _nutSettings = nutSettings;
        }

        public void Accelerate(float delta)
        {
            _acceleration += delta;
            _acceleration = Mathf.Clamp(_acceleration, -_nutSettings.MaxAcceleration, _nutSettings.MaxAcceleration);
        }

        public void Slowdown(float maxDelta)
        {
            _acceleration = Mathf.MoveTowards(_acceleration, StopSpeed, maxDelta);
        }

        public void Stop()
        {
            _acceleration = StopSpeed;
        }
    }
}