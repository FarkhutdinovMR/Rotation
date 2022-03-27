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
        transform.SetPositionAndRotation(new Vector3(transform.position.x, position, transform.position.z), Quaternion.Euler(new Vector3(0, -rotation, 0)));
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