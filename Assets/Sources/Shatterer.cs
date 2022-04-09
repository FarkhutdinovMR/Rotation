using System.Collections.Generic;
using UnityEngine;

public class Shatterer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pieces;
    [SerializeField] private Health _health;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _deleteTime;

    private int _initPiecesCount;

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void Start()
    {
        _initPiecesCount = _pieces.Count;
    }

    private void OnHealthChanged()
    {
        float healthInPercent = _health.Value / _health.MaxHealth * 100;
        int remainPiecesCount = Mathf.CeilToInt(healthInPercent * _initPiecesCount / 100);

        while(_pieces.Count > remainPiecesCount)
        {
            int randomPieceIndex = Random.Range(0, _pieces.Count);
            GameObject piece = _pieces[randomPieceIndex];
            Push(piece);
            piece.transform.parent = null;
            Destroy(piece, _deleteTime);
            _pieces.Remove(piece);
        }
    }

    private void Push(GameObject piece)
    {
        if (piece.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.useGravity = true;
            rigidbody.AddForce(piece.transform.forward * _pushForce, ForceMode.Impulse);
        }
    }
}