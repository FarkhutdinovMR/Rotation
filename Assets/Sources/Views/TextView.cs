using UnityEngine;
using TMPro;

public class TextView : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _format;
    [SerializeField] private TMP_Text _text;

    public void UpdateText(string value)
    {
        _text.SetText($"{_name} {value}");
    }

    public void UpdateText(float value)
    {
        _text.SetText($"{_name} {value.ToString(_format)}");
    }
}