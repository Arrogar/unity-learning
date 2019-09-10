using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;

    int score;

    void Start() {
        scoreText.text = "Score: ";
        Events.OnScoreUpdate += updateScore;
    }
    
    void OnDisable() {
        Events.OnScoreUpdate -= updateScore;
    }

    void updateScore(int newScore) {
        score += newScore;

        updateScoreText();
    }

    void updateScoreText() {
        scoreText.text = "Score: " + score;
    }
}
