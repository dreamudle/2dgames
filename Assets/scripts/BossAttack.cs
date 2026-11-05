using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Hazard[] projectiles;    // префабы Hazard (огонь, камень, бомба)
    public Transform player;
    public float pause = 2f;        // окно, когда можно подойти и стрелять
    public float projectileSpeed = 5f;

    void Start() { StartCoroutine(AttackLoop()); }

    IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(pause);
            for (int i = 0; i < 3; i++)
            {
                Shoot();
                yield return new WaitForSeconds(0.4f);
            }
        }
    }

    void Shoot()
    {
        Hazard prefab = projectiles[Random.Range(0, projectiles.Length)];
        Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
        Vector3 spawnPos = transform.position + (Vector3)(dir * 1.5f);   // чуть впереди босса
        Hazard h = Instantiate(prefab, spawnPos, Quaternion.identity);

        // бомба не сталкивается с самим боссом
        Collider2D bc = h.GetComponent<Collider2D>();
        Collider2D myc = GetComponent<Collider2D>();
        if (bc != null && myc != null) Physics2D.IgnoreCollision(bc, myc);

        StartCoroutine(Launch(h));
    }

    IEnumerator Launch(Hazard h)
    {
        yield return null;   // ждем, пока отработает Start у Hazard
        if (h == null || player == null) yield break;
        Rigidbody2D rb = h.GetComponent<Rigidbody2D>();
        if (rb == null) yield break;
        Vector2 dir = ((Vector2)player.position - (Vector2)h.transform.position).normalized;
        rb.linearVelocity = dir * projectileSpeed;
    }
}