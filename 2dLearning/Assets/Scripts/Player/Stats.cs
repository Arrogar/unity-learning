using UnityEngine;

public class Stats : MonoBehaviour {
    #region Stats properties
    public int score = 0;
    public int strength = 0;
    public int agility = 0;
    public int health = 0;
    public int defense = 0;
    public float jumpForce = 5f;
    public float speed = 3f;
    #endregion

    void Start() {
        Events.OnLevelUpStatsUpdate += levelUpStatsUpdate;
    }

    void levelUpStatsUpdate() {
        Stats newStats = new Stats();

        newStats.health = Random.Range(1, 10);
        newStats.strength = Random.Range(1, 3);
        newStats.agility = Random.Range(1, 3);

        updateStats(newStats);
    }

    public int getScore() {
        return score;
    }

    public void updateStats(Stats newStats) {
        health += newStats.health;
        strength += newStats.strength;
        agility += newStats.agility;
        defense += newStats.defense;

        jumpForce += (newStats.agility / jumpForce) / 2f;
        speed += (newStats.agility / speed) / 2f;

        Events.TriggerStatsUpdate(this);
    }

    public void updateScore(int newScore) {
        score += newScore;

        Events.TriggerScoreUpdate(score);
    }
}
