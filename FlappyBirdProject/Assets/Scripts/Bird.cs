using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class Bird : MonoBehaviour {

    private const float JUMP_AMOUNT = 100f;
    private Rigidbody2D rigidBody;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Jump();
        }
    }

    private void Jump() {
        rigidBody.velocity = Vector2.up * JUMP_AMOUNT;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        CMDebug.TextPopupMouse("Dead!");
    }
}
