using UnityEngine;

namespace Influences
{
    public class InverterInfluence : MonoBehaviour
    {
        [SerializeField] private NutInit _nut;

        private void OnTriggerEnter(Collider other)
        {
            _nut.InertRotation.InvertDirection();
        }

        private void OnTriggerExit(Collider other)
        {
            _nut.InertRotation.InvertDirection();
        }
    }
}