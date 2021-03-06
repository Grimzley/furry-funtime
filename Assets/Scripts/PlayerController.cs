using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;

    public Transition transition;

    public Animator animator;

    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public bool jump = false;

    public Transform player;
    public Transform spawnPoint;

    public void Start() {
        transition = GameObject.Find("Transition").GetComponent<Transition>();
    }
    public void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }
    public void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Gem") {
            GameManager.OnGemPickUp();
            Destroy(collision.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Death") {
            GameManager.Death();
            if (GameManager.numberOfLives > 0) {
                Respawn();
            }else {
                RemovePlayer();
            }
        }
        else if (collision.collider.tag == "LevelEnd") {
            GameManager.NextLevel();
            transition.LoadNextLevel();
            RemovePlayer();
        }
    }
    public void Respawn() {
        player.position = spawnPoint.position;
    }
    // Used to prevent player from moving around during 'Game Over' screen or crossfade transition
    public void RemovePlayer() {
        Destroy(player.gameObject);
    }
}
