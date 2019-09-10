using UnityEngine;

public class Randomizer : MonoBehaviour {
    void Start() {
        Stats stats = GetComponent<Stats>();
        Level level = GetComponent<Level>();

        level.levelModifier = Random.Range(0.01f, 0.3f);

        stats.health = (int)Random.Range(0f + level.levelModifier, 1f + level.levelModifier);
        stats.defense = (int)Random.Range(0f + level.levelModifier, 1f + level.levelModifier);
        stats.strength = (int)Random.Range(0f + level.levelModifier, 1f + level.levelModifier);
        stats.agility = (int)Random.Range(0f + level.levelModifier, 1f + level.levelModifier);

        stats.jumpForce = Random.Range(0f + level.levelModifier, 0.5f + level.levelModifier);
        stats.speed = Random.Range(0f + level.levelModifier, 0.5f + level.levelModifier);
        stats.score = (int)Random.Range(1f + level.levelModifier, 3f + level.levelModifier);

        level.experience = (int)Random.Range(1 + level.levelModifier, 3f + level.levelModifier);
    }
}
