using UnityEngine;
using TMPro;

public class FPC : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _updateRate = 1;

    private int _frame;
    private float _time;

    private void Start()
    {
        InvokeRepeating(nameof(OnUpdate), 0, _updateRate);
    }

    private void Update()
    {
        _frame++;
        _time += Time.timeScale / Time.deltaTime;
    }

    private void OnUpdate()
    {
        float fpc = _time / _frame;
        _text.SetText($"FPC {fpc.ToString("F0")}");
        _frame = 0;
        _time = 0;
    }
}