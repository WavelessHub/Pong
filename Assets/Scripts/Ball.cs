using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool canLaunch = false;

    [SerializeField] private float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        canLaunch = false;
        rb.linearVelocity = Vector2.zero;
    }

    void Update()
    {
        if (!canLaunch && GameManager.instance.HasGameStarted())
        {
            canLaunch = true;
            Launch();
        }

        // Always keep ball moving at constant speed
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? 1 : -1;
        float y = Random.Range(-0.7f, 0.7f); // small y value for better gameplay

        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player)
            AudioManager.instance.PlaySFX(1);

        // Maintain speed after collision
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }
}
