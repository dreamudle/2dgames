using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    [HideInInspector] public float direction = 1f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direction * speed, 0f);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Hazard>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        Boss boss = other.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeHit(1);
            Destroy(gameObject);
        }
    }
}