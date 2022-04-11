using UnityEngine;

namespace Influences
{
    public class FrictionInfluence : MonoBehaviour
    {
        [SerializeField] private NutSettings _nutSettings;
        [SerializeField] private NutInit _nut;
        [SerializeField] private Caster _boltCast;

        private void OnTriggerStay(Collider other)
        {
            if (_boltCast.IsCollision)
                _nut.InertRotation.Slowdown(_nutSettings.Friction);
        }
    }
}