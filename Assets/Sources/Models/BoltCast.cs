using UnityEngine;

public class BoltCast : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _boxSize;

    private bool _inAir;

    public bool InAir => _inAir;

    private void OnDrawGizmos()
    {
        if (_inAir)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, _boxSize * 2);
    }

    private void Update()
    {
        if (IsCollision())
            _inAir = false;
        else
            _inAir = true;
    }

    private bool IsCollision()
    {
        return Physics.OverlapBox(transform.position, _boxSize, Quaternion.identity, _layerMask).Length > 0;
    }
}