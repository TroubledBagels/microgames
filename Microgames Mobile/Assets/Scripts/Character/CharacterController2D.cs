using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
2D only in name
This is the base script for all "2D" movement in the game
This script is attached to the player object and allows the character to move left, right, up and down, similar to Mario rather than bomber man.

If you're looking for bomberman style, go to CharacterControllerTD.cs (Top Down)
*/

public class CharacterController2D : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider bc;
    public Joystick js;
    public Button jb;
    public GameController gc;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;
    private bool isMoving;
    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        js = GameObject.Find("Movement Stick").GetComponent<Joystick>();
        jb = GameObject.Find("Jump Button").GetComponent<Button>();

        jb.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        if (js.Horizontal < 0) {
            MoveLeft();
        }
        else if (js.Horizontal > 0) {
            MoveRight();
        }

        if (isGrounded) {
            isJumping = false;
            isFalling = false;
        }
        if (rb.velocity.y > 0) {
            isJumping = true;
            isFalling = false;
        }
        if (rb.velocity.y < 0) {
            isJumping = false;
            isFalling = true;
        }
        if (rb.velocity.x == 0) {
            isMoving = false;
        }

        if (rb.velocity.x > 10) {
            rb.velocity = new Vector3(10, rb.velocity.y, 0);
        }
        if (rb.velocity.x < -10) {
            rb.velocity = new Vector3(-10, rb.velocity.y, 0);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    public void MoveLeft() {
        if (isGrounded) {
            rb.velocity = new Vector3(5 * js.Horizontal, rb.velocity.y, 0);
            isMoving = true;
            isFacingRight = false;
        } else {
            rb.velocity = rb.velocity + new Vector3(-0.05f, 0, 0);
            isMoving = true;
            isFacingRight = false;
        }
    }

    public void MoveRight() {
        if (isGrounded) {
            rb.velocity = new Vector3(5 * js.Horizontal, rb.velocity.y, 0);
            isMoving = true;
            isFacingRight = true;
        } else {
            rb.velocity = rb.velocity + new Vector3(0.05f, 0, 0);
            isMoving = true;
            isFacingRight = true;
        }
    }

    public void Jump() {
        if (isGrounded) {
            rb.velocity = new Vector3(rb.velocity.x, 10, 0);
            isJumping = true;
            isGrounded = false;
        }
    }
}
