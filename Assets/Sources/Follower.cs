using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _yOffset;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, _target.position.y + _yOffset), transform.position.z);
    }

    public void Reset()
    {
        transform.position = startPosition;
    }
}