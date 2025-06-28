using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public bool isPlayerOne;

    [SerializeField] private float movementSpeed = 10f;

    void Update()
    {
        if (!GameManager.instance.HasGameStarted())
        {
            transform.position = new Vector2(transform.position.x, 0f);
            rb.linearVelocity = Vector2.zero; // stop movement
            return;
        }

        float yOneInput = Input.GetAxisRaw("PlayerOne");
        float yTwoInput = Input.GetAxisRaw("PlayerTwo");

        float linearVelocityY = (isPlayerOne ? yOneInput : yTwoInput) * movementSpeed;
        rb.linearVelocity = new Vector2(0f, linearVelocityY);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);
        transform.position = pos;
    }
}
