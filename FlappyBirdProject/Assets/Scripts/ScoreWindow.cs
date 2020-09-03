using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour {

    private Text highscoreText;
    private Text scoreText;

    private void Awake() {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        highscoreText = transform.Find("HighscoreText").GetComponent<Text>();
    }

    private void Start() {
        highscoreText.text = "HIGHSCORE: " + Score.GetHighscore().ToString();
        Bird.GetInstance().OnDied += ScoreWindow_OnDied;
        Bird.GetInstance().OnStartedPlaying += ScoreWindow_OnStartedPlaying;
        Hide();
    }

    private void ScoreWindow_OnStartedPlaying(object sender, EventArgs e) {
        Show();
    }

    private void ScoreWindow_OnDied(object sender, EventArgs e) {
        Hide();
    }

    private void Update() {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }
}
