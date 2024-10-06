using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 1.0f; // Speed will be assigned by the spawner

    private void Update()
    {
        // Move the obstacle from right to left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroy the obstacle when it goes off-screen
        if (transform.position.x < -Camera.main.aspect * Camera.main.orthographicSize - 2)
        {
            Destroy(gameObject);
        }
    }
}
