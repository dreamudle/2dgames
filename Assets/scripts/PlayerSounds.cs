using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip coinClip;
    public AudioClip jumpClip;

    AudioSource src;
    Rigidbody2D rb;
    float prevVy;

    void Start()
    {
        src = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float vy = rb.linearVelocity.y;

        if (prevVy < 0.1f && vy > 2f && jumpClip != null)
            src.PlayOneShot(jumpClip);

        prevVy = vy;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin") && coinClip != null)
            src.PlayOneShot(coinClip);
    }
}