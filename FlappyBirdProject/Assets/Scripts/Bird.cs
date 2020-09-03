using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using System;

public class Bird : MonoBehaviour {

    private const float JUMP_AMOUNT = 100f;
    private Rigidbody2D rigidBody;
    private static Bird instance;

    public static Bird GetInstance() {
        return instance;
    }

    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;

    private State state;

    private enum State {
        WaitingToStart,
        Playing,
        Dead
    }


    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        instance = this;
        rigidBody.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
    }

    private void Update() {
        switch (state) {
            default:
            case State.WaitingToStart:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                    state = State.Playing;
                    rigidBody.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    OnStartedPlaying?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                    Jump();
                }
                break;
            case State.Dead:
                break;
        }

    }

    private void Jump() {
        rigidBody.velocity = Vector2.up * JUMP_AMOUNT;
        SoundManager.PlaySound(SoundManager.Sound.BirdJump);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        rigidBody.bodyType = RigidbodyType2D.Static;
        SoundManager.PlaySound(SoundManager.Sound.Lose);
        OnDied?.Invoke(this, EventArgs.Empty);
    }
}
