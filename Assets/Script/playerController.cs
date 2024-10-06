using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
    public GameObject playerBullet;
    public bool playerIsImmortal = false; // Here you can cheat ;)
    public int playerLives = 3; // read by GUI script
    public bool isGameOver = false; // read by GUI script

    // Tuning
    private float pushUpForce = 6.0f; // force applied when fly button is tapped
    private float playerBulletXOffset = 0.5f;
    private float playerBulletYOffset = 0f;
    private float timeBetweenShots = 0.2f;  // 0.2 = 5 shots per second
    private float timestamp;

    private Rigidbody2D rb; // Reference to Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity for the player
    }

	void FixedUpdate()
	{
		if (Input.GetButton("Up"))
		{
			upArrowPressed();
		}
		if (Input.GetButton("Down"))
		{
			downArrowPressed();
		}
		if (Input.GetButton("Right"))
		{
			forwardArrowPressed();
		}
		if (Input.GetButton("Left"))
		{
			backArrowPressed();
		}

		if (Input.GetButton("Fire2"))
		{
			Fire2Pressed();
		}

		// Clamp the player's position within the screen boundaries
		ClampPlayerPosition();
	}

	void ClampPlayerPosition()
	{
		// Get the main camera
		Camera cam = Camera.main;
		
		// Calculate screen boundaries in world coordinates
		float halfHeight = cam.orthographicSize; // Height of the view is from -halfHeight to halfHeight
		float halfWidth = cam.orthographicSize * cam.aspect; // Width of the view is from -halfWidth to halfWidth

		// Get current position
		Vector2 newPosition = transform.position;

		// Clamp the x position within the screen boundaries
		newPosition.x = Mathf.Clamp(newPosition.x, -halfWidth, halfWidth);

		// Clamp the y position within the screen boundaries
		newPosition.y = Mathf.Clamp(newPosition.y, -halfHeight, halfHeight);

		// Set the player's position
		transform.position = newPosition;
	}

    void upArrowPressed() 
    {
        // Move up
        rb.AddForce(new Vector2(0, pushUpForce));
    }

    void downArrowPressed() 
    {
        // Move down
        rb.AddForce(new Vector2(0, -pushUpForce));
    }

    void forwardArrowPressed() 
    {
        // Move right
        rb.AddForce(new Vector2(pushUpForce, 0));
    }

    void backArrowPressed() 
    {
        // Move left
        rb.AddForce(new Vector2(-pushUpForce, 0));
    }

    void Fire2Pressed() 
    {
        if (Time.time >= timestamp) 
        {
            // Shoot bullet
            Instantiate(playerBullet, transform.position + new Vector3(playerBulletXOffset, playerBulletYOffset, 0), Quaternion.identity);
            timestamp = Time.time + timeBetweenShots;
        }
    }

    void OnTriggerEnter2D(Collider2D thisObject)
    {
        playerDidCollide();
    }

    void OnCollisionEnter2D(Collision2D thisObject)
    {
        playerDidCollide();
    }

    void playerDidCollide() 
    {
        if (playerLives > 0 && !playerIsImmortal) 
        {
            playerLives -= 1; // lose 1 life
        } 
        else if (playerLives <= 0 && !playerIsImmortal) 
        {
            gameOver();
        }
    }

    void gameOver() 
    {
        isGameOver = true; // This is picked by the Update function in GUI.cs
        Time.timeScale = 0.0F; // Stop the game
    }

    void Update() 
    {
        if (isGameOver && (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))) 
        {
            Time.timeScale = 1.0F; // Restart the time
            Application.LoadLevel(Application.loadedLevel); // Reload this level
        }
    }
}