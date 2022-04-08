namespace Models
{
    public class Transformable
    {
        private readonly NutSettings _nutSettings;
        private float _rotation;

        public Transformable(NutSettings nutSettings)
        {
            _nutSettings = nutSettings;
        }

        public float Rotation => _rotation;

        public float Position => _rotation * _nutSettings.MovePerRotate;

        public void Rotate(float angle)
        {
            _rotation += angle;
        }
    }
}