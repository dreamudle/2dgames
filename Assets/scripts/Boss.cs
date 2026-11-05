using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int maxHp = 5;
    public Slider hpBar;            // полоска HP на Canvas
    public string nextScene = "Win";

    int hp;

    void Start()
    {
        hp = maxHp;
        if (hpBar != null) { hpBar.maxValue = maxHp; hpBar.value = hp; }
    }

    public void TakeHit(int dmg)
    {
        hp -= dmg;
        if (hpBar != null) hpBar.value = hp;
        if (hp <= 0) SceneManager.LoadScene(nextScene);
    }
}