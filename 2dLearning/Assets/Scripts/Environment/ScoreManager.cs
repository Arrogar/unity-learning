using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public Text pickedPickupsText;
    public Text WinText;
    public Text LoseText;
    public Button RestartButton;

    int score;
    int pickedPickupsCount = 0;
    int pickupsLeft;

    GameManager gm;

    void Start() {
        Events.OnScoreUpdate += updateScore;
        Events.OnPickupPick += updatePickupsLeft;
        Events.OnWin += handleWin;
        Events.OnGameOver += handleGameOver;

        gm = GetComponent<GameManager>();
        pickupsLeft = gm.totalPickups;

        scoreText.text = "Score: ";
        WinText.text = "";
        LoseText.text = "";
        pickedPickupsText.text = pickedPickupsCount + "/" + pickupsLeft;

        RestartButton.gameObject.SetActive(false);
    }
    
    void OnDisable() {
        Events.OnScoreUpdate -= updateScore;
        Events.OnPickupPick -= updatePickupsLeft;
        Events.OnWin -= handleWin;
        Events.OnGameOver -= handleGameOver;
    }

    void updateScore(int newScore) {
        score += newScore;

        updateScoreText();
    }

    void updatePickupsLeft() {
        pickedPickupsCount++;

        pickedPickupsText.text = pickedPickupsCount + "/" + pickupsLeft;
    }

    void updateScoreText() {
        scoreText.text = "Score: " + score;
    }

    void handleWin() {
        WinText.text = "You Win!";
        RestartButton.gameObject.SetActive(true);
    }

    void handleGameOver() {
        LoseText.text = "You lose!\nRestart in " + Mathf.RoundToInt(gm.restartGameTimer) + " seconds";
        RestartButton.gameObject.SetActive(true);
    }
}
