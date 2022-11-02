using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private TextMeshProUGUI _textScoreUI;
    [SerializeField] private TextMeshProUGUI _textHighScoreUI;
    private int _score = 0;
    private static int _highScore = 0;
    private string _scoreString = "Score: ";
    private string _highScoreString = "High score: ";

    void Start()
    {
        SpeedController.OnSpeedIncreased.AddListener(UpdateOwnSpeed);
        Player.OnPlayerDeath.AddListener(ResetCounter);
        StartCoroutine(IncreaseScore());
        _textScoreUI.text = _scoreString + _score.ToString("0000");
        _textHighScoreUI.text = _highScoreString + _highScore.ToString("0000");
    }


    void Update()
    {
        
    }

    private IEnumerator IncreaseScore()
    {
        _score++;
        if (_score > _highScore)
        {
            _highScore = _score;
        }
        _textScoreUI.text = _scoreString + _score.ToString("0000");
        _textHighScoreUI.text = _highScoreString + _highScore.ToString("0000");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(IncreaseScore());
    }

    void ResetCounter()
    {
        StopAllCoroutines();
        if (_score > _highScore)
            _score = _highScore;
        _score = 0;
    }

    private void UpdateOwnSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
