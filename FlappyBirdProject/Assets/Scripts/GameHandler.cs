using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {
    // Start is called before the first frame update

    private static bool firstTime = true;

    void Start() {
        if (firstTime) {
            Score.ResetHighscore();
            firstTime = false;
        }

        Score.Start();
    }
}

