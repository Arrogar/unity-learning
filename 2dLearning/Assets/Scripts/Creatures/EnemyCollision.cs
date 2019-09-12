using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Events.TriggerGameOver();
        }
    }
}
