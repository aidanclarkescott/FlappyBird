using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour {

    public void Play() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        Loader.Load(Loader.Scene.GameScene);
    }

    public void Quit() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        Application.Quit();
    }

    public void ButtonOverSound() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
    }


}
