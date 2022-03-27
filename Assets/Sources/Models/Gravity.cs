using System;

namespace Models
{
    public class Gravity : IRotation
    {
        private readonly IRotation _rotation;
        private readonly float _scale;

        public Gravity(IRotation rotation, float scale)
        {
            if (rotation == null)
                throw new ArgumentNullException(nameof(rotation));

            _rotation = rotation;
            _scale = scale;
        }

        public void Rotate(float direction)
        {
            _rotation.Rotate(direction);
        }

        public void Update(float deltaTime)
        {
            _rotation.Rotate(_scale * deltaTime);
        }
    }
}