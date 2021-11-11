using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinAndXPCollector : MonoBehaviour
{
    private int coinCount = 0;
    private int xpCount = 0;
    private int xpMultiplier = 1;

    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI xpText;
    private float lastCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            CoinCollected coinCollected = collision.GetComponent<CoinCollected>();
            if (!coinCollected.isCollected)
            {
                Destroy(collision.gameObject);
                coinCollected.isCollected = true;
                coinCount++;
                Debug.Log(Time.time - lastCoinCollected);
                // Resets the xpMultiplier to 1 if coin is not collected within 10 seconds of the last one (breaks positive feedback loop)
                if (Time.time - lastCoinCollected > 10)
                {
                    ResetXPMultiplier();
                }
                lastCoinCollected = Time.time;
                Debug.Log("XP Multiplier: " + xpMultiplier.ToString()); ;
                xpCount += 1 * xpMultiplier;
                xpMultiplier++;
                coinCountText.text = "Coins: " + coinCount.ToString();
                xpText.text = "XP: " + xpCount.ToString();
            }
        }
    }

    public void ResetXPMultiplier()
    {
        xpMultiplier = 1;
    }
}
