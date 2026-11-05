using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHp = 3;
    public int hp = 3;
    public AudioClip hurtClip;
    public AudioClip healClip;

    bool invincible;
    SpriteRenderer sr;
    AudioSource src;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        src = GetComponent<AudioSource>();
        hp = maxHp;
    }

    public void TakeDamage(int dmg)
    {
        if (invincible) return;
        hp -= dmg;
        Debug.Log("HP: " + hp);
        if (src != null && hurtClip != null) src.PlayOneShot(hurtClip);
        if (hp <= 0) { GameOver(); return; }
        StartCoroutine(Invincibility());
    }

    public void Heal(int amount)
    {
        hp = Mathf.Min(hp + amount, maxHp);
        Debug.Log("HP: " + hp);
        if (src != null && healClip != null) src.PlayOneShot(healClip);
    }

    IEnumerator Invincibility()
    {
        invincible = true;
        for (int i = 0; i < 10; i++)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.2f);
        }
        sr.enabled = true;
        invincible = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}