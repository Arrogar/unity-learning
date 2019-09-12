using UnityEngine;

public class EnemyChase : MonoBehaviour {
    public float rangedAttackRange;
    public float minDistance = 1f;
    public float maxDistance = 10f;
    public float speed = 1f;
    public float delayBetweenDirection = 2f;

    [SerializeField]bool isInRangeToFollow = false;
    [SerializeField]bool isNearPlayer = false;
    [SerializeField]float distance;
    [SerializeField]Vector2 nextDirection;

    float delayInitValue;

    Rigidbody2D enemyRb;
    Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRb = GetComponent<Rigidbody2D>();
        delayInitValue = delayBetweenDirection;
    }

    void updateNearPlayerStatus(float distance) {
        isNearPlayer = distance <= minDistance + 0.3f;
    }

    void updateInPlayerFollowRangeStatus(float distance) {
        isInRangeToFollow = distance < maxDistance - 0.2f;
    }

    // Track and decide if the enemy should follow the player or just wander around
    void trackPlayer(float distance) {

        if (distance > minDistance && distance <= maxDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // enemy jump [TODO: Allow the enemy to have certain amounts of jumps same as player]
            if (isNearPlayer && !player.GetComponent<PlayerMovement>().isTouchingGround) {
                enemyRb.velocity = Vector2.up * 3f;
            }
        } else {
            if (!isNearPlayer) {
                delayBetweenDirection -= Time.deltaTime;

                transform.position = Vector2.MoveTowards(transform.position, nextDirection, speed * Time.deltaTime);

                if (delayBetweenDirection <= 0f) {
                    nextDirection = (Vector2)transform.position - new Vector2(Random.Range(transform.position.x +- 10f, transform.position.x + 10f), 0f);
                    delayBetweenDirection = delayInitValue;
                }
            }
        }
    }

    void Update() {
        distance = Vector2.Distance(transform.position, player.position);

        updateNearPlayerStatus(distance);
        updateInPlayerFollowRangeStatus(distance);
        trackPlayer(distance);
    }
}
