using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float horizontalInput;
    Vector2 playerMove;
    Rigidbody2D playerRb;
    Stats stats;

    public float checkRadius;
    public int extraJumps;

    int extraJumpValue;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public AudioSource audioSource;
    public AudioClip jumpAudio;
    public Animator Animator;

    // bool facingRight = false;
    bool isGrounded;
    public bool isTouchingGround;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();

        extraJumpValue = extraJumps;
    }

    void Update() {
        if (isGrounded) {
            extraJumps = extraJumpValue;
            Animator.SetBool("JumpCondition", false);
        } else {
            Animator.SetBool("JumpCondition", true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (extraJumps > 0) {
                audioSource.PlayOneShot(jumpAudio);
                playerRb.velocity = Vector2.up * stats.jumpForce;
                extraJumps--;
            } else if (extraJumps == 0 && isGrounded) {
                audioSource.PlayOneShot(jumpAudio);
                playerRb.velocity = Vector2.up * stats.jumpForce;
            }
        }
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isTouchingGround = isGrounded;
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(horizontalInput * stats.speed, playerRb.velocity.y);

        // if (!facingRight && horizontalInput > 0) {
        //     Flip();
        // } else if (facingRight && horizontalInput < 0) {
        //     Flip();
        // }
    }

    // void Flip() {
    //     facingRight = !facingRight;
    //     Vector3 Scaler = transform.localScale;
    //     Scaler.x *= -1;
    //     transform.localScale = Scaler;
    // }
}
