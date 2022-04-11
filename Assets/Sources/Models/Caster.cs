using System;
using UnityEngine;

public class Caster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _boxSize;

    private bool _isCollison;
    private Collider[] _colliders;

    public bool IsCollision => _isCollison;

    public Vector3 HalfSize => _boxSize * 0.5f;

    private Collider _firstCollider => _colliders[0];

    private void OnDrawGizmos()
    {
        if (_isCollison)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, _boxSize);
    }

    private void Update()
    {
        if (Cast())
            _isCollison = true;
        else
            _isCollison = false;
    }

    public float ComputePenetration()
    {
        if (_isCollison == false)
            throw new InvalidOperationException();

        float halfHeight1 = HalfSize.y;
        float halfHeight2 = _firstCollider.bounds.extents.y;
        float necessaryDistance = Math.Max(halfHeight1, halfHeight2) - Math.Min(halfHeight1, halfHeight2);

        float factDistance = Math.Max(transform.position.y, _firstCollider.transform.position.y) - Math.Min(transform.position.y, _firstCollider.transform.position.y);

        return necessaryDistance - factDistance;
    }

    public int Direction()
    {
        if (_isCollison == false)
            throw new InvalidOperationException();

        return transform.position.y > _firstCollider.transform.position.y ? -1 : 1;
    }

    private bool Cast()
    {
        _colliders = Physics.OverlapBox(transform.position, HalfSize, Quaternion.identity, _layerMask);

        return _colliders.Length > 0;
    }
}