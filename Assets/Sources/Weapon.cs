using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private NutInit _nut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
            health.TakeDamage(Mathf.Abs(_nut.InertRotation.Acceleration) * _nutSettings.Damage);
    }
}