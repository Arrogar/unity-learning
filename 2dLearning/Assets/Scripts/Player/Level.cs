using UnityEngine;

public class Level : MonoBehaviour {
    #region Level properties
    public int level = 0;
    public int experience;
    public int maxExperience = 20;
    public float levelModifier = 1.5f;
    #endregion

    public AudioSource audioSource;
    public AudioClip levelUpSound;

    void Start() {
        maxExperience = 20;
    }

    public void updateExperience(Level currentLevel) {
        experience += currentLevel.experience;

        Events.TriggerExperienceUpdate(this);

        levelUpCheck(experience);
    }

    public void levelUpCheck(int newExperience) {
        if (experience >= maxExperience) {
            int expLeft = (int)(newExperience - maxExperience);

            updateLevel();

            experience += expLeft;

            Events.TriggerExperienceUpdate(this);
            Events.TriggerOnLevelUpStatsUpdate();
        }
    }

    public void updateLevel() {
        level++;
        experience = 0;
        maxExperience = (int)(maxExperience * levelModifier);

        audioSource.PlayOneShot(levelUpSound);
        Events.TriggerLevelUp(this);
    }
}
