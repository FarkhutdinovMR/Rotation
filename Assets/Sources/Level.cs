using UnityEngine;
using Models;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level : MonoBehaviour
{
    [SerializeField] private Init _init;
    [SerializeField] private float _delayAfterWin;

    private Transformable _transformable;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _transformable = _init.Model;
        _transformable.Ended += OnEnded;
    }

    private void OnDisable()
    {
        _transformable.Ended -= OnEnded;
    }

    private void OnEnded()
    {
        if (_coroutine != null)
            return;

        _coroutine = StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(_delayAfterWin);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _coroutine = null;
    }
}