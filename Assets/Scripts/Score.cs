using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The class that contains and controls game score.
/// </summary>
public class Score : MonoBehaviour
{
    public static Score instance;

    private int _score;

    [SerializeField] private int _targetScore = 4000; // Score to end game.

    [SerializeField] private Text _scoreText = null;

    void Start()
    {
        instance = this;
    }
    public void SetScore(int score)
    {
        _score += score;
        _scoreText.text = "Score: " + _score.ToString();
        if(_score >= _targetScore)
        {
            GameController.instance.GameEnd($"You win!\n Your score: {_score.ToString()}");
        }
    }
}
