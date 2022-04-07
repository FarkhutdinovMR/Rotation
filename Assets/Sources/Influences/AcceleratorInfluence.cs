using UnityEngine;

namespace Influences
{
    public class AcceleratorInfluence : MonoBehaviour
    {
        [SerializeField] private float _valueInPercent;
        [SerializeField] private NutInit _nut;

        private void OnTriggerStay(Collider other)
        {
            _nut.InertRotation.Accelerate(_nut.InertRotation.Acceleration * _valueInPercent * 0.01f);
        }
    }
}