namespace Models
{
    public class Transformable
    {
        private float _position;
        private float _rotation;

        public float Position => _position;

        public float Rotation => _rotation;

        public void Translate(float translation)
        {
            _position += translation;
        }

        public void Rotate(float angle)
        {
            _rotation += angle;
        }
    }
}