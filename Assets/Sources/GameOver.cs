using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private float _yOffset;
    [SerializeField] private GameObject _gameOverWindow;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Levels _level;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartLevel);
    }

    private void Update()
    {
        ExitToScreen();
    }

    private void EndGame()
    {
        _gameOverWindow.SetActive(true);
        Time.timeScale = 0;
    }

    private void ExitToScreen()
    {
        Vector3 position = _camera.WorldToViewportPoint(_target.position + new Vector3(0, _yOffset, 0));

        if (position.y < 0)
            EndGame();
    }

    private void RestartLevel()
    {
        _level.RestartLevel();
        _gameOverWindow.SetActive(false);
    }
}