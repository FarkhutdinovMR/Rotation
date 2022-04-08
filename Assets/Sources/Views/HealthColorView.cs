using UnityEngine;

public class HealthColorView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Color _damagingColor;
    [SerializeField] private MeshRenderer _renderer;

    private Material _material;
    private Color _startColor;

    private void Start()
    {
        _material = _renderer.material;
        _startColor = _material.color;
    }

    private void Update()
    {
        _material.color = Color.Lerp(_damagingColor, _startColor, _health.Value / _health.MaxHealth);
    }
}