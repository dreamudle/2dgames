using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Health playerHealth;
    public PlayerMovement player;
    public Image[] hearts;          // 3 картинки сердец
    public TMP_Text coinsText;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
            hearts[i].enabled = i < playerHealth.hp;

        coinsText.text = "Coins: " + player.Coins + " / " + player.CoinsTotal;
    }
}