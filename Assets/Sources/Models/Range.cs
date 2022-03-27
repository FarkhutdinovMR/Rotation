using System;

namespace Models
{
    [Serializable]
    public struct Range
    {
        private readonly float _min;
        private readonly float _max;

        public Range(float min, float max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException($"{nameof(min)} must be less then {nameof(max)}");

            _min = min;
            _max = max;
        }

        public float Min => _min;

        public float Max => _max;
    }
}