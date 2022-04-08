using Models;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private NutInit _init;
    [SerializeField] private float _delayAfterWin;
    [SerializeField] private GameObject _congratulationWindow;
    [SerializeField] private Button _nextLevelButton;

    private Transformable _transformable;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _transformable = _init.Transformable;
        _nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void OnDisable()
    {
    }

    private void OnEnded(float angle)
    {
        if (_coroutine != null)
            return;

        _coroutine = StartCoroutine(AddDelay());
    }

    private IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(_delayAfterWin);
        _congratulationWindow.SetActive(true);
        _coroutine = null;
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}