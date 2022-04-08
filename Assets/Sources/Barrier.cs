using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if ()
    }
}