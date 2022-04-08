using UnityEngine;

namespace Models
{
    public class PhysicCollision
    {
        private readonly Transformable _transformable;
        private readonly Vector3 _colliderSize;

        public PhysicCollision(Transformable transformable, Vector3 colliderSize)
        {
            _transformable = transformable;
            _colliderSize = colliderSize;
        }

        private Vector3 _colliderPosition => new Vector3(0, _transformable.Position, 0);

        public void OnDrawGizmo()
        {
            if (IsCollisionEnter(out Collider[] colliders))
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;

            Gizmos.DrawWireCube(_colliderPosition, _colliderSize * 2);
        }

        public bool IsCollisionEnter(out Collider[] colliders)
        {
            colliders = Physics.OverlapBox(_colliderPosition, _colliderSize);

            return colliders.Length > 0;
        }
    }
}