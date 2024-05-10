// This script is an upgrade that increases the players health

using UnityEngine;
using TMPro;

public class IncreaseHealthUpgrade : MonoBehaviour
{
    public HitPoints playerHitPoints;
    public AcornCollection acornCollection;
    public int healthUpgradeCost = 20; // Amount of Acorns to purchase upgrades

    public void TryIncreaseHealth()
    {
        if (acornCollection.Acorns >= healthUpgradeCost) // Checks if the player has enough acorns
        {
            acornCollection.UseAcorns(healthUpgradeCost); // Removes acorns after player presses purchase
            IncreaseHealth(); // Increases player health
        }
    }

    private void IncreaseHealth()
    {
        playerHitPoints.maxHP += 1;  // Increase maximum HP by 1
        playerHitPoints.currentHP = playerHitPoints.maxHP;  // Sets a new maximum health
    }
}