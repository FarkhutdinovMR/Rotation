using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finisher : MonoBehaviour
{
    [SerializeField] private float _delayAfterWin;
    [SerializeField] private GameObject _congratulationWindow;
    [SerializeField] private Button _nextLevelButton;

    private Coroutine _coroutine;

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
        if (_coroutine != null)
            return;

        _coroutine = StartCoroutine(AddDelay());
    }

    private IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(_delayAfterWin);
        Time.timeScale = 0;
        _congratulationWindow.SetActive(true);
        _coroutine = null;
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}