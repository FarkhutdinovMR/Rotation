using System;
using UnityEngine;

namespace Models
{
    public class InertRotation
    {
        private readonly float _unitPerSecond;
        private readonly float _slowdown;
        private readonly float _rotateMaxSpeed;

        private float _acceleration;

        public event Action<float> AccelerationChanged;

        public InertRotation(float unitPerSecond, float slowdown, float rotateMaxSpeed)
        {
            _unitPerSecond = unitPerSecond;
            _slowdown = slowdown;
            _rotateMaxSpeed = rotateMaxSpeed;
        }

        public float Accelerate(float delta)
        {
            _acceleration = delta * _unitPerSecond;
            _acceleration = Mathf.Clamp(_acceleration, -_rotateMaxSpeed, _rotateMaxSpeed);
            AccelerationChanged?.Invoke(_acceleration);
            return _acceleration;
        }

        public float Slowdown()
        {
            _acceleration = Mathf.MoveTowards(_acceleration, 0, _slowdown * Time.deltaTime);
            AccelerationChanged?.Invoke(_acceleration);
            return _acceleration;
        }
    }
}