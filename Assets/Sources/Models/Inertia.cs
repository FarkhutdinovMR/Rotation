using System;
using UnityEngine;

namespace Models
{
    public class Inertia : IRotation
    {
        private readonly IRotation _rotation;
        private readonly float _maxSpeed;
        private readonly float _unitPerSecond;

        private float _acceleration;
        private bool _isChanged;

        public Inertia(IRotation rotation, float maxSpeed, float unitPerSecond)
        {
            _rotation = rotation;
            _maxSpeed = maxSpeed;
            _unitPerSecond = unitPerSecond;
        }

        public event Action<float> AccelerationChanged;

        public void Rotate(float angle)
        {
            Accelerate(angle);
            _isChanged = true;
        }

        public void Update()
        {
            if (_isChanged == false)
                Slowdown();

            _rotation.Rotate(_acceleration);
            _isChanged = false;
            AccelerationChanged?.Invoke(_acceleration);
        }

        private void Accelerate(float direction)
        {
            _acceleration += direction * _unitPerSecond * Time.deltaTime;
            _acceleration = Mathf.Clamp(_acceleration, -_maxSpeed, _maxSpeed);
        }

        private void Slowdown()
        {
            _acceleration = Mathf.MoveTowards(_acceleration, 0, _unitPerSecond * Time.deltaTime);
        }
    }
}