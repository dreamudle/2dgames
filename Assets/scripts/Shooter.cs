using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldown = 0.3f;
    public AudioClip shootClip;

    float nextShot;
    SpriteRenderer sr;
    AudioSource src;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        src = GetComponent<AudioSource>();
    }

    // вызывается из PlayerMovement.OnFire()
    public void Shoot()
    {
        if (Time.time < nextShot) return;
        nextShot = Time.time + cooldown;

        float dir = sr.flipX ? -1f : 1f;

        GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        b.GetComponent<Bullet>().direction = dir;

        if (src != null && shootClip != null) src.PlayOneShot(shootClip);
    }
}