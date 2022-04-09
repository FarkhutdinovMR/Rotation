using UnityEngine;

[CreateAssetMenu(fileName = "NewNutSettings", menuName = "Nut", order = 41)]
public class NutSettings : ScriptableObject
{
    [field: SerializeField] public float MaxAngularSpeed { get; private set; }

    [field: SerializeField] public float RotateScale { get; private set; }

    [field: SerializeField] public float MovePerRotate { get; private set; }

    [field: SerializeField] public int Damage { get; private set; }
}