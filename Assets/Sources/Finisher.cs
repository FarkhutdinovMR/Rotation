using UnityEngine;
using UnityEngine.UI;

public class Finisher : MonoBehaviour
{
    [SerializeField] private GameObject _congratulationWindow;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private NutInit _nut;
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private Follower _camera;
    [SerializeField] private GameObject[] _levels;

    private int _currentLevel;

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
        _levels[_currentLevel].SetActive(false);

        int nextLevel = _currentLevel + 1;

        if (nextLevel >= _levels.Length)
            return;

        _levels[nextLevel].SetActive(true);

        _nut.Transformable.Rotate(transform.position.y / _nutSettings.MovePerRotate * -1);

        _camera.Reset();

        _congratulationWindow.SetActive(false);

        Time.timeScale = 1;

        _currentLevel = nextLevel;
    }
}