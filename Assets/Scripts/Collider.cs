using UnityEngine;

public class Collider : MonoBehaviour
{
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();

        if (ball)
        {
            float position = transform.position.x;

            if (position > 0)
                gameManager.IncrementPlayerOneScore();
            else
                gameManager.IncrementPlayerTwoScore();

            AudioManager.instance.PlaySFX(2);

            Instantiate(ball, Vector2.zero, Quaternion.identity);

            Destroy(ball);
        }
    }
}