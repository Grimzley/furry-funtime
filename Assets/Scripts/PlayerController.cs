using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public bool jump = false;

    public void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }
    public void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Gem") {
            GameManager.OnGemPickUp();
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "LevelEnd") {
            GameManager.NextLevel();
        }
    }
}
