using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private NutInit _nut;

    private void OnTriggerStay(Collider other)
    {
        _nut.InertRotation.Accelerate(_velocity);
    }
}