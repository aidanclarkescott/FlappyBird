﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score {

    public static void Start() {
        Bird.GetInstance().OnDied += Bird_OnDied;
    }

    private static void Bird_OnDied(object sender, EventArgs e) {
        TrySetNewHighscore(Level.GetInstance().GetPipesPassedCount());
    }

    public static int GetHighscore() {
        return PlayerPrefs.GetInt("highscore");
    }

    public static bool TrySetNewHighscore(int score) {
        if (score > GetHighscore()) {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            return true;
        }

        return false;
    }

    public static void ResetHighscore() {
        PlayerPrefs.SetInt("highscore", 0);
        PlayerPrefs.Save();
    }

}
