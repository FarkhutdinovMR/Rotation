using UnityEngine;

public class RotationView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        DisablePhysics();
    }

    public void Rotate(float rotation, float position)
    {
        var _position = new Vector3(transform.position.x, position, transform.position.z);
        var _rotation = Quaternion.Euler(new Vector3(0, -rotation, 0));

        transform.SetPositionAndRotation(_position, _rotation);
    }

    private void DisablePhysics()
    {
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
    }

    public void EnablePhysics(float direction)
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.right, ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.down * direction * 20);
    }
}