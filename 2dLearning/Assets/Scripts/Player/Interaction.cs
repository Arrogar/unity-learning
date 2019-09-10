using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour {
    public ScoreManager scoreManager;

    public Stats stats;
    public Level currentLevel;

    void Start() {
        // init
        Events.TriggerStatsUpdate(stats);
        Events.TriggerExperienceUpdate(currentLevel);
        Events.TriggerLevelUp(currentLevel);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Pickup")) {
            Pickup pickup = collider.GetComponent<Pickup>();
            Stats pickupStats = collider.GetComponent<Stats>();
            Level pickupLevel = collider.GetComponent<Level>();
            AudioSource pickupDestroySound = collider.GetComponent<AudioSource>();
            string statsText = "";

            if (pickupStats != null) {
                stats.updateScore(pickupStats.getScore());
                stats.updateStats(pickupStats);
                currentLevel.updateExperience(pickupLevel);

                if (pickupStats.strength > 0) {
                    statsText += "+" + pickupStats.strength + "str ";
                }

                if (pickupStats.agility > 0) {
                    statsText += "+" + pickupStats.agility + "agi ";
                }

                if (pickupStats.defense > 0) {
                    statsText += "+" + pickupStats.defense + "def ";
                }

                if (pickupStats.health > 0) {
                    statsText += "+" + pickupStats.health + "hp ";
                }
            }

            // Show xp
            pickup.expText.text = pickupLevel.experience.ToString() + " XP";

            pickup.statsText.text = statsText;
            // Play destroy sound
            pickupDestroySound.Play();
            // init particle
            ParticleSystem destroyParticle = Instantiate(pickup.destroyParticle, collider.transform.position, Quaternion.identity);
            // destroy object
            collider.GetComponent<MeshRenderer>().enabled = false;
            collider.GetComponent<Collider2D>().enabled = false;
            Destroy(destroyParticle.gameObject, destroyParticle.main.duration + 0.5f);
            Destroy(collider.gameObject, destroyParticle.main.duration + 1f);
        }
    }
}
