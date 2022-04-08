using UnityEngine;

namespace Influences
{
    public class PusherInfluence : MonoBehaviour
    {
        [SerializeField] private NutInit _nut;
        [SerializeField] private float _power;

        private void OnTriggerEnter(Collider other)
        {
            _nut.InertRotation.Accelerate(_power * _nut.InertRotation.Acceleration * -1);
        }
    }
}