using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour {

    public void Play() {
        Loader.Load(Loader.Scene.GameScene);
    }

    public void Quit() {
        Application.Quit();
    }


}
