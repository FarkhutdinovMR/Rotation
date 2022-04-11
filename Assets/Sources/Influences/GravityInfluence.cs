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
                _nut.InertRotation.Accelerate(_nutSettings.Gravity);
        }
    }
}