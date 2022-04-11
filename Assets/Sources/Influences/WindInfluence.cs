using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private NutInit _nut;

    private void OnTriggerStay(Collider other)
    {
        _nut.InertRotation.Accelerate(_nutSettings.Wind * transform.up.y * -1);
    }
}