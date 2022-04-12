using UnityEngine;
using UnityEngine.UI;

public class Finisher : MonoBehaviour
{
    [SerializeField] private GameObject _congratulationWindow;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Levels _level;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(NextLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Finish finish))
            OnFinishEntered();
    }

    private void OnFinishEntered()
    {
        _congratulationWindow.SetActive(true);
        Time.timeScale = 0;
    }

    private void NextLevel()
    {
        _level.NextLevel();
        _congratulationWindow.SetActive(false);
    }
}