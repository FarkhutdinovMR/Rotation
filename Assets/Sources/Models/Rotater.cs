using UnityEngine;

namespace Models
{
    public class Rotater : IRotation
    {
        private readonly IRotation _rotation;
        private readonly float _unitPerSecond;

        public Rotater(IRotation rotation, float unitPerSecond)
        {
            _rotation = rotation;
            _unitPerSecond = unitPerSecond;
        }

        public void Rotate(float angle)
        {
            _rotation.Rotate(angle * _unitPerSecond * Time.deltaTime);
        }
    }
}