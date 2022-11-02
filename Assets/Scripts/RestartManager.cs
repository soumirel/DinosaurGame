using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    private bool isAlive = true;
    private bool _isPaused = false;
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private TreeGenerator _treeGenerator;
    public static UnityEvent OnGamePaused = new UnityEvent();

    public void Start()
    {
        Player.OnPlayerDeath.AddListener(HandleDeath);
    }

    public void Update()
    {
        if (!_isPaused)
        {
            if (!isAlive && _treeGenerator.treesCount == 0)
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        _isPaused = true;
        OnGamePaused.Invoke();
        _pauseMenuUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _isPaused = false;
        isAlive = true;
    }

    private void HandleDeath()
    { 
        isAlive = false;
    }
}
