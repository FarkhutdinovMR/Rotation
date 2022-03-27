using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void LateUpdate()
    {
        //Vector3 position = new Vector3(0, Mathf.Max(_target.position.y, transform.position.y), 0);
        //transform.position = position + _offset;

        Vector3 position = _target.position + _offset;
        transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.deltaTime);
    }
}