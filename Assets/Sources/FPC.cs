using UnityEngine;
using TMPro;

public class FPC : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        InvokeRepeating(nameof(OnUpdate), 0, 1);
    }

    private void OnUpdate()
    {
        _text.SetText(((int)(1 / Time.unscaledDeltaTime)).ToString());
    }
}