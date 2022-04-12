using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private NutInit _nut;
    [SerializeField] private NutSettings _nutSettings;
    [SerializeField] private Follower _camera;
    [SerializeField] private Movement _movement;

    private List<GameObject> _levels = new List<GameObject>();
    private int _currentLevelIndex;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject level = transform.GetChild(i).gameObject;
            _levels.Add(level);

            if (level.activeSelf)
                _currentLevelIndex = i;
        }
    }

    public void RestartLevel()
    {
        InitLevel();
    }

    public void NextLevel()
    {
        _levels[_currentLevelIndex].SetActive(false);
        int nextLevel = _currentLevelIndex + 1;
        if (nextLevel >= _levels.Count)
            nextLevel = 0;

        _levels[nextLevel].SetActive(true);
        _currentLevelIndex = nextLevel;

        InitLevel();
    }

    private void InitLevel()
    {
        _nut.Init();
        _movement.Init();
        _camera.Reset();
        Time.timeScale = 1;
    }
}