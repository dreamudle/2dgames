using UnityEngine;

public class BombHazard : Hazard
{
    public float fuse = 2f;
    public float radius = 1.5f;
    public GameObject explosionEffect;
    public AudioClip boomClip;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Explode), fuse);
    }

    protected override void OnHitPlayer(Health p)
    {
        CancelInvoke(nameof(Explode));
        p.TakeDamage(2);
    }

    void Explode()
    {
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        if (boomClip != null)
            AudioSource.PlayClipAtPoint(boomClip, transform.position);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D h in hits)
        {
            if (h.CompareTag("Player"))
                h.GetComponent<Health>().TakeDamage(2);
        }
        Destroy(gameObject);
    }
}