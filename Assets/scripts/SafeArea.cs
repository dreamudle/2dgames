using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rt;
    Rect last;

    void Update()
    {
        Rect s = Screen.safeArea;
        if (s == last) return;
        last = s;

        if (rt == null) rt = GetComponent<RectTransform>();

        Vector2 min = s.position;
        Vector2 max = s.position + s.size;
        min.x /= Screen.width; min.y /= Screen.height;
        max.x /= Screen.width; max.y /= Screen.height;

        rt.anchorMin = min;
        rt.anchorMax = max;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }
}