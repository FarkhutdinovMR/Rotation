using System;
using UnityEngine;

namespace Models
{
    public class Inertia
    {
        private readonly IRotation _rotation;
        private readonly float _maxSpeed;
        private readonly float _unitPerSecond;
        private readonly float _slowdown;

        private float _acceleration;
        private float _previousAngle;

        public Inertia(IRotation rotation, float maxSpeed, float unitPerSecond, float slowdown)
        {
            _rotation = rotation;
            _maxSpeed = maxSpeed;
            _unitPerSecond = unitPerSecond;
            _slowdown = slowdown;
        }

        public event Action<float> AccelerationChanged;

        public void Rotate()
        {
            _rotation.Rotate(_acceleration * Time.deltaTime);
            Slowdown();
        }

        public void Update(float angle)
        {
            if (Mathf.Approximately(_previousAngle, angle))
                Slowdown();
            else
                Accelerate(angle);

            _previousAngle = angle;
        }

        private void Accelerate(float direction)
        {
            _acceleration += direction * _unitPerSecond * Time.deltaTime;
            _acceleration = Mathf.Clamp(_acceleration, -_maxSpeed, _maxSpeed);
            AccelerationChanged?.Invoke(_acceleration);
        }

        private void Slowdown()
        {
            _acceleration = Mathf.MoveTowards(_acceleration, 0, _slowdown * Time.deltaTime);
            AccelerationChanged?.Invoke(_acceleration);
        }
    }
}