using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Transform player;

    void Update() {
        if (player.position.y < -10) {
            SceneManager.LoadScene(0);
        }
    }
}
