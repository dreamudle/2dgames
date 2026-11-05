using UnityEngine;

public class SurvivalTimer : MonoBehaviour
{
    public float goal = 60f;
    public GameObject portal;
    public AudioClip portalClip;

    float t;
    bool won;
    AudioSource src;

    void Start()
    {
        src = GetComponent<AudioSource>();
        portal.SetActive(false);
    }

    void Update()
    {
        if (won) return;
        t += Time.deltaTime;
        if (t >= goal)
        {
            won = true;
            Debug.Log("YOU WIN!");
            portal.SetActive(true);
            if (portalClip != null)
                src.PlayOneShot(portalClip);
        }
    }
}