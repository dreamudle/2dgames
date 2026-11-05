using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 8f;
    public string nextScene;

    private Rigidbody2D rb;
    private bool onGround;
    private float x;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int coins;
    private int coinsTotal;

    public GameObject movingCoin;
    public float coinHeight = 2f;
    public float coinSpeed = 2f;
    private Vector3 coinStartPosition;

    public int Coins => coins;
    public int CoinsTotal => coinsTotal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        coinsTotal = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("Coins in this level: " + coinsTotal);

        if (movingCoin != null)
            coinStartPosition = movingCoin.transform.position;
    }

    // Input System (PlayerInput, Send Messages) вызывает эти методы сам
    public void OnMove(InputValue value)
    {
        x = value.Get<Vector2>().x;
    }

    public void OnJump()
    {
        if (onGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            onGround = false;
        }
    }

    public void OnFire()
    {
        GetComponent<Shooter>().Shoot();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetBool("Grounded", onGround);

        if (x != 0)
            spriteRenderer.flipX = x < 0;

        if (movingCoin != null)
        {
            float newY = coinStartPosition.y +
                         Mathf.Sin(Time.time * coinSpeed) * coinHeight;

            movingCoin.transform.position = new Vector3(
                coinStartPosition.x,
                newY,
                coinStartPosition.z
            );
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Ground")) return;

        foreach (ContactPoint2D c in other.contacts)
        {
            if (c.normal.y > 0.5f)
            {
                onGround = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            onGround = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins: " + coins + " / " + coinsTotal);
        }

        if (other.CompareTag("Exit"))
        {
            if (coins >= coinsTotal)
                SceneManager.LoadScene(nextScene);
            else
                Debug.Log("Collect all coins first! " + coins + " / " + coinsTotal);
        }
    }
}