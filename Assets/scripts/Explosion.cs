using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float duration = 0.4f;
    public float maxScale = 3f;

    float t;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Destroy(gameObject, duration);
    }

    void Update()
    {
        t += Time.deltaTime;
        float k = t / duration;
        transform.localScale = Vector3.one * Mathf.Lerp(0.3f, maxScale, k);

    }
}