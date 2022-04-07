using UnityEngine;

namespace Influences
{
    public class FrictionInfluence : MonoBehaviour
    {
        [SerializeField] private float _valueInPercent;
        [SerializeField] private NutInit _nut;

        private void OnTriggerStay(Collider other)
        {
            _nut.InertRotation.Slowdown(_valueInPercent);
        }
    }
}