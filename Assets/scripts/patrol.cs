using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    Vector3 start;
    float lastX;
    SpriteRenderer sr;

    void Start()
    {
        start = transform.position;
        lastX = start.x;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance);
        float newX = start.x + offset;
        transform.position = new Vector3(newX, start.y, start.z);

        if (sr != null && newX != lastX)
            sr.flipX = newX < lastX;
        lastX = newX;
    }
}