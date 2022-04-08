using UnityEngine;

public class RotationView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void Rotate(float rotation, float position)
    {
        var _position = new Vector3(transform.position.x, position, transform.position.z);
        var _rotation = Quaternion.Euler(new Vector3(0, -rotation, 0));

        transform.SetPositionAndRotation(_position, _rotation);
    }
}