using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public GameObject dashEffect;
    public GameObject jumpEffect;
    public CameraShakeScript cameraShake;
    public AudioClip jumpSFX;
    public AudioClip dashSFX;
    public AudioClip deathSFX;
    private Rigidbody2D body;

    private float speed;
    private Vector3 movement;
    public static Vector3 respawnPoint;

    private float jumpForce;
    private bool jump;
    private bool grounded;
    private int jumpCount;
    private int maxJumps;

    private float startDashTime;
    private float dashTime;
    private float dashSpeed;
    private float lastDash;
    private float dashInterval;
    private int checkpoint;
    private Animation anim;

    // Direction player is dashing (not dashing: 0, right: 1, left: 2)
    private string directionDashing;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        speed = 10f;
        jumpForce = 500f;
        jump = false;
        grounded = false;
        jumpCount = 0;
        maxJumps = 1;
        startDashTime = 0.05f;
        dashSpeed = 50;
        lastDash = -1;
        dashInterval = 2;
        respawnPoint = this.transform.position;
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (LevelManager.canMove)
        {
            // Assigns the change in movement along the x-axis
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                // This enables the player to jump again if they jumped from the ground, but not if they just rolled off something.
                if (grounded)
                    maxJumps = 2;
            }
        }
    }

    void FixedUpdate()
    {
        if (LevelManager.canMove)
        {
            // Moves the player left or right based on their input
            transform.position += movement * speed * Time.fixedDeltaTime;
            if (jump)
                JumpCharacter();
            Dash();
        }
    }

    // Jumps the character and adds to the jump counter.
    void JumpCharacter()
    {
        if (grounded || jumpCount < maxJumps)
        {
            body.velocity = new Vector2(0, 0);
            body.AddForce(new Vector2(0, jumpForce));
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
            if (!grounded)
                Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y - 0.3f, 0), Quaternion.identity);
            jumpCount++;
            grounded = false;
        }
        jump = false;
    }

    // Checks if the player is attemping to dash left or right and responds appropriately.
    void Dash()
    {
        if (directionDashing == "None")
        {
            if (Input.GetKeyDown(KeyCode.E) && ((lastDash + dashInterval < Time.time) || lastDash == -1))
                directionDashing = "Right";
            if (Input.GetKeyDown(KeyCode.Q) && ((lastDash + dashInterval < Time.time) || lastDash == -1))
                directionDashing = "Left";
        }
        else
        {
            if (dashTime <= 0)
            {
                directionDashing = "None";
                dashTime = startDashTime;
                body.velocity = Vector2.zero;
            }
            else
            {
                if (directionDashing == "Right")
                {
                    dashTime -= Time.deltaTime;
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(dashSFX, Camera.main.transform.position);
                    body.velocity = Vector2.right * dashSpeed;
                    StartCoroutine(cameraShake.Shake(.05f, .2f));
                    lastDash = Time.time;
                }
                if (directionDashing == "Left")
                {
                    dashTime -= Time.deltaTime;
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(dashSFX, Camera.main.transform.position);
                    body.velocity = Vector2.left * dashSpeed;
                    StartCoroutine(cameraShake.Shake(.05f, .2f));
                    lastDash = Time.time;
                }
            }
        }
    }

    void FadePlayer(float value)
    {
        SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
        Color color = renderer.color;
        color.a = value;
        renderer.color = new Color(color.r, color.g, color.b, color.a);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        maxJumps = 1;
        grounded = true;
        jumpCount = 0;
        switch (collider.gameObject.tag)
        {
            case "FadeBlock":
                FadePlayer(0.4f);
                break;
            case "UnfadeBlock":
                FadePlayer(1f);
                break;
            case "Checkpoint 1":
                if (checkpoint < 1)
                    respawnPoint = collider.transform.position;
                collider.gameObject.SetActive(false);
                checkpoint = 1;
                break;
            case "Checkpoint 2":
                if (checkpoint < 2)
                    respawnPoint = collider.transform.position;
                collider.gameObject.SetActive(false);
                checkpoint = 2;
                break;
            case "Checkpoint 3":
                if (checkpoint < 3)
                    respawnPoint = collider.transform.position;
                collider.gameObject.SetActive(false);
                checkpoint = 3;
                break;
            case "Appearing Checkpoint 3":
                if (checkpoint < 3)
                    respawnPoint = collider.transform.position;
                collider.gameObject.SetActive(false);
                checkpoint = 3;
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        grounded = false;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        maxJumps = 1;
        grounded = true;
        jumpCount = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Spike"))
        {
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
            anim.Play("PlayerDeathAnimation");
            LevelManager.canMove = false;
            Invoke("RespawnPlayer", 0.7f);
        }
    }

    public void RespawnPlayer()
    {
        this.transform.position = respawnPoint;
        LevelManager.canMove = true;
    }
}