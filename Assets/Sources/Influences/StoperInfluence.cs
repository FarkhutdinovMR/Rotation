using UnityEngine;

public class StoperInfluence : MonoBehaviour
{
    [SerializeField] private NutInit _nut;

    private void OnTriggerEnter(Collider other)
    {
        _nut.InertRotation.Stop();
    }
}