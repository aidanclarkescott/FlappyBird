using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System;

public class GameOverWindow : MonoBehaviour {
    private Text scoreText;

    private void Awake() {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
    }

    public void Restart() {
        Loader.Load(Loader.Scene.GameScene);
    }

    public void MainMenu() {
        Loader.Load(Loader.Scene.MainMenu);
    }

    private void Start() {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, EventArgs e) {
        scoreText.text = scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
        Show();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }
}
