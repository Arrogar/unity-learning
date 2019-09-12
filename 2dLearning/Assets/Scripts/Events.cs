public static class Events {
    #region Event Delegates
    public delegate void StatsUpdate(Stats stats);
    public delegate void ScoreUpdate(int score);
    public delegate void ExperienceUpdate(Level level);
    public delegate void LevelUp(Level level);
    public delegate void LevelUpStatsUpdate();
    public delegate void PickupPicked();
    public delegate void GameOverEvent();
    public delegate void WinEvent();
    #endregion

    #region Events Definitions
    public static event StatsUpdate OnStatsUpdate;
    public static event ScoreUpdate OnScoreUpdate;
    public static event ExperienceUpdate OnExperienceUpdate;
    public static event LevelUp OnLevelUp;
    public static event LevelUpStatsUpdate OnLevelUpStatsUpdate;
    public static event PickupPicked OnPickupPick;
    public static event GameOverEvent OnGameOver;
    public static event WinEvent OnWin;
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

    public static void TriggerOnPickupPick() {
        if (OnPickupPick != null) {
            OnPickupPick();
        }
    }

    public static void TriggerGameOver() {
        if (OnGameOver != null) {
            OnGameOver();
        }
    }

    public static void TriggerWinGame() {
        if (OnWin != null) {
            OnWin();
        }
    }
    #endregion
}
