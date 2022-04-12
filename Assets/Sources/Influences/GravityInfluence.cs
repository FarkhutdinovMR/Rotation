using UnityEngine;

namespace Influences
{
    public class GravityInfluence : MonoBehaviour
    {
        [SerializeField] private NutSettings _nutSettings;
        [SerializeField] private NutInit _nut;
        [SerializeField] private Caster _boltCast;

        private void OnTriggerStay(Collider other)
        {
            if (_boltCast.IsCollision == false)
            {
                float time = _nut.InertRotation.Acceleration / _nutSettings.MaxAcceleration;
                float evalution = _nutSettings.Gravity.Evaluate(time);
                _nut.InertRotation.Accelerate(evalution);
            }
        }
    }
}