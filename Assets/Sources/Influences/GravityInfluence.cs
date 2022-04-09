using UnityEngine;

namespace Influences
{
    public class GravityInfluence : MonoBehaviour
    {
        [SerializeField] private float _gravity;
        [SerializeField] private NutInit _nut;
        [SerializeField] private BoltCast _boltCast;

        private void OnTriggerStay(Collider other)
        {
            if (_boltCast.InAir)
                _nut.InertRotation.Accelerate(_gravity);
        }
    }
}