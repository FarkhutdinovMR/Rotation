using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;
    [SerializeField] private NutInit _nut;

    private void LateUpdate()
    {
        Vector3 position = _target.position + _offset;
        transform.position = Vector3.MoveTowards(transform.position, position, Mathf.Abs(_nut.InertRotation.Acceleration) * _speed);
    }
}