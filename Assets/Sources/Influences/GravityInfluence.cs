using UnityEngine;

namespace Influences
{
    public class GravityInfluence : MonoBehaviour
    {
        [SerializeField] private float _gravity;
        [SerializeField] private NutInit _nut;
        [SerializeField] private Movement _movement;

        private void OnTriggerStay(Collider other)
        {
            if (_movement.InAir)
                _nut.InertRotation.Accelerate(_gravity);
        }
    }
}