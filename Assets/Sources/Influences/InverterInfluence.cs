using UnityEngine;

namespace Influences
{
    public class InverterInfluence : MonoBehaviour
    {
        [SerializeField] private Movement _movement;

        private void OnTriggerEnter(Collider other)
        {
            _movement.InvertDirection();
        }

        private void OnTriggerExit(Collider other)
        {
            _movement.InvertDirection();
        }
    }
}