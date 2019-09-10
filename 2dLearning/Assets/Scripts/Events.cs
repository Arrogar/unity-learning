public static class Events {
    #region Event Delegates
    public delegate void StatsUpdate(Stats stats);
    public delegate void ScoreUpdate(int score);
    public delegate void ExperienceUpdate(Level level);
    public delegate void LevelUp(Level level);
    public delegate void LevelUpStatsUpdate();
    #endregion

    #region Events Definitions
    public static event StatsUpdate OnStatsUpdate;
    public static event ScoreUpdate OnScoreUpdate;
    public static event ExperienceUpdate OnExperienceUpdate;
    public static event LevelUp OnLevelUp;
    public static event LevelUpStatsUpdate OnLevelUpStatsUpdate;
    #endregion

    #region Events Triggers
    public static void TriggerStatsUpdate(Stats stats) {
        if (OnStatsUpdate != null) {
            OnStatsUpdate(stats);
        }
    }

    public static void TriggerScoreUpdate(int score) {
        if (OnScoreUpdate != null) {
            OnScoreUpdate(score);
        }
    }

    public static void TriggerExperienceUpdate(Level level) {
        if (OnExperienceUpdate != null) {
            OnExperienceUpdate(level);
        }
    }

    public static void TriggerLevelUp(Level level) {
        if (OnLevelUp != null) {
            OnLevelUp(level);
        }
    }

    public static void TriggerOnLevelUpStatsUpdate() {
        if (OnLevelUpStatsUpdate != null) {
            OnLevelUpStatsUpdate();
        }
    }
    #endregion
}
