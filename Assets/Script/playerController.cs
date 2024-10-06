using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public GameObject playerBullet;
    public bool playerIsImmortal = false; // Cheat mode
    public int playerLives = 3; // Player starts with 3 lives
    public bool isGameOver = false; // Flag to detect game over

    // Tuning parameters
    private float pushUpForce = 6.0f; // Force applied to move the player
    private float playerBulletXOffset = 0.5f;
    private float playerBulletYOffset = 0f;
    private float timeBetweenShots = 0.2f; // Time between shots
    private float timestamp;

    private Rigidbody2D rb; // Reference to Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Up"))
        {
            MoveUp();
        }
        if (Input.GetButton("Down"))
        {
            MoveDown();
        }
        if (Input.GetButton("Right"))
        {
            MoveRight();
        }
        if (Input.GetButton("Left"))
        {
            MoveLeft();
        }

        if (Input.GetButton("Fire2"))
        {
            Shoot();
        }

        // Restrict the player's movement within the screen boundaries
        ClampPlayerPosition();
    }

    // Method to restrict player within screen bounds
    void ClampPlayerPosition()
    {
        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.orthographicSize * cam.aspect;

        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -halfWidth, halfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -halfHeight, halfHeight);

        transform.position = newPosition;
    }

    // Movement controls
    void MoveUp()
    {
        rb.AddForce(new Vector2(0, pushUpForce));
    }

    void MoveDown()
    {
        rb.AddForce(new Vector2(0, -pushUpForce));
    }

    void MoveRight()
    {
        rb.AddForce(new Vector2(pushUpForce, 0));
    }

    void MoveLeft()
    {
        rb.AddForce(new Vector2(-pushUpForce, 0));
    }

    // Shooting logic
    void Shoot()
    {
        if (Time.time >= timestamp)
        {
            // Fire the bullet
            Instantiate(playerBullet, transform.position + new Vector3(playerBulletXOffset, playerBulletYOffset, 0), Quaternion.identity);
            timestamp = Time.time + timeBetweenShots;
        }
    }

    // Detecting collisions with obstacles
    void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    // Handle player collision
    void HandleCollision(GameObject collidedObject)
    {
        if (collidedObject.CompareTag("Obstacle"))
        {
            if (!playerIsImmortal) // If the player isn't immortal
            {
                playerLives--; // Lose one life

                if (playerLives <= 0)
                {
                    gameOver(); // Trigger game over when lives reach 0
                }
                else
                {
                    Debug.Log("Player hit an obstacle! Remaining lives: " + playerLives);
                }
            }
        }
    }

    // Handle game over logic
    void gameOver()
    {
        isGameOver = true; // Set game over flag
        Time.timeScale = 0.0F; // Stop the game
        Debug.Log("Game Over!");
    }

    // Restart the game when it’s over
    void Update()
    {
        if (isGameOver && (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)))
        {
            // Reset game time and reload the level
            Time.timeScale = 1.0F;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
