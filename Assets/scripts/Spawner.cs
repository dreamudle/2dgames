using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Hazard[] prefabs;
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 4f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 2f);
    }

    void Spawn()
    {
        Hazard pick = prefabs[Random.Range(0, prefabs.Length)];
        float x = Random.Range(minX, maxX);
        Instantiate(pick, new Vector3(x, spawnY, 0f), Quaternion.identity);
    }
}