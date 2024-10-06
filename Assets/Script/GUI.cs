using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour 
{
    public int currentScore = 0;
    public bool isGameOver;
    public int playerLives;

    private Text livesText;
    private Text scoreText;
    private Text gameOverText;
    private playerController playerController;

    void Start() 
    {
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
        playerController = GameObject.Find("Player").GetComponent<playerController>();
    }

    void Update() 
    {
        if (playerController != null) 
        {
            playerLives = playerController.playerLives;
            isGameOver = playerController.isGameOver;
            livesText.text = "LIVES: " + playerLives;
            scoreText.text = "SCORE: " + currentScore;
            gameOverText.enabled = isGameOver;
        } 
        else 
        {
            Debug.LogWarning("PlayerController not found. Please ensure the player object is named 'Player' and has the PlayerController component.");
        }
    }
}
