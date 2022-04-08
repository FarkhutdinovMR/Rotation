using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _angularSpeed;

    private void Update()
    {
        transform.Rotate(_angularSpeed * Time.deltaTime * Vector2.up);
    }
}