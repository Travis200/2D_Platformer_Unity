using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is used to track the amount of coins and XP collected and display these values on the screen during gameplay. 
/// </summary>
public class CoinAndXPCollector : MonoBehaviour
{
    private int coinCount = 0;
    private int xpCount = 0;
    private int xpMultiplier = 1;

    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI xpText;
    private float lastCoinCollected;

    /// <summary>
    /// If the player collides with a coin then it is collected and added to the coin count. XP is also added and the xp multiplier is incremented by one.
    /// I have made the XP follow a positive feedback mechanic so that if the coin is collected within 10 seconds of the last coin then the XP multiplier
    /// increases by one, or if not it is reset to one. This means that as a player starts to collect coins and gain XP the more coins, they collect in
    /// short successsion will result in more XP. When a coin is collected the xpMutiplier value is added to the current amount of XP.
    /// </summary>
    /// <param name="collision">Only when the collision is a coin, the coin count and XP count are increased.</param>
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
                // Store timestamp when last coin collected
                lastCoinCollected = Time.time;
                Debug.Log("XP Multiplier: " + xpMultiplier.ToString()); ;
                xpCount += 1 * xpMultiplier;
                xpMultiplier++;
                coinCountText.text = "Coins: " + coinCount.ToString();
                xpText.text = "XP: " + xpCount.ToString();
            }
        }
    }

    /// <summary>
    /// Used to reset the xpMultiplier to one. 
    /// </summary>
    public void ResetXPMultiplier()
    {
        xpMultiplier = 1;
    }
}
