using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Transform player;
    public int totalPickups;
    public float restartGameTimer = 10f;

    bool hasToRestart = false;

    void Awake() {
        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        Events.OnGameOver += EndGame;
        Events.OnWin += WinGame;
    }

    void OnDisable() {
        Events.OnGameOver -= EndGame;
        Events.OnWin -= WinGame;
    }

    void Update() {
        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        if (totalPickups == 0) {
            Events.TriggerWinGame();
        }

        if (player.position.y < -10 && !hasToRestart) {
            Events.TriggerGameOver();
        }

        if (hasToRestart) {
            restartGameTimer -= Time.deltaTime;

            if (restartGameTimer < 0.1f) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void WinGame() {
        hasToRestart = true;
        Events.OnGameOver -= EndGame;
    }

    void EndGame() {
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.01f;

        hasToRestart = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
