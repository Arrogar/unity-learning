using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {
    public Text healthText;
    public Text strengthText;
    public Text agilityText;
    public Text defenseText;
    public Text experienceText;
    public Text levelText;

    public Slider experienceSlider;

    RectTransform experienceSliderTransform;

    int health;
    int defense;
    int strength;
    int agility;
    int experience;
    int level;
    int maxValueExp;

    float sliderWidth = Screen.width - 100f;

    void Awake() {
        #region Event listeners
        Events.OnStatsUpdate += updateStats;
        Events.OnExperienceUpdate += updateExperience;
        Events.OnLevelUp += updateLevel;
        #endregion
    }

    void Start() {
        experienceSliderTransform = experienceSlider.GetComponent<RectTransform>();

        experienceSliderTransform.sizeDelta = new Vector2(sliderWidth, experienceSliderTransform.rect.height);
    }

    void OnDisable() {
        #region Detach events
        Events.OnStatsUpdate -= updateStats;
        Events.OnExperienceUpdate -= updateExperience;
        Events.OnLevelUp -= updateLevel;
        #endregion
    }

    void updateStats(Stats stats) {
        updateStatsGUI(stats);
    }

    void updateExperience(Level currentLevel) {
        experience = currentLevel.experience;
        maxValueExp = currentLevel.maxExperience;

        experienceSlider.value = experience;
        experienceSlider.maxValue = maxValueExp;
        experienceText.text = "Exp: " + experience + "/" + maxValueExp;
    }

    void updateLevel(Level newLevel) {
        level = newLevel.level;
        experienceSlider.maxValue = newLevel.maxExperience;

        levelText.text = level.ToString();
    }

    void updateStatsGUI(Stats stats) {
        healthText.text = "HP: " + stats.health;
        strengthText.text = "Strength: " + stats.strength;
        agilityText.text = "Agility: " + stats.agility;
        defenseText.text = "Defense: " + stats.defense;
    }
}
