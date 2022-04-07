using System;
using UnityEngine;

namespace Models
{
    public class Transformable : IRotation
    {
        private readonly Range _rotationRange;
        private readonly Range _positionRange;

        private float _rotation;
        private float _position;
        private bool _isEnd;

        public Transformable(Range rotationRange, Range positionRange)
        {
            _rotationRange = rotationRange;
            _positionRange = positionRange;
        }

        public event Action<float, float> Transformated;

        public event Action<float> Ended;

        public float Position => _position;

        public void Rotate(float angle)
        {
            if (_isEnd)
                return;

            _rotation += angle;
            _rotation = Mathf.Clamp(_rotation, _rotationRange.Min, _rotationRange.Max);

            if (_rotation >= _rotationRange.Max)
            {
                _isEnd = true;
                Ended?.Invoke(angle);
            }

            Translate();

            Transformated?.Invoke(_rotation, _position);
        }

        private void Translate()
        {
            _position = Mathf.Lerp(_positionRange.Min, _positionRange.Max, _rotation / _rotationRange.Max);
        }
    }
}