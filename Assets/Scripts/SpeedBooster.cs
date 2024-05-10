// Upgrade to increase the players speed

using UnityEngine;
using TMPro;

public class SpeedBooster : MonoBehaviour
{
    public PlayerController playerController;
    public AcornCollection acornCollection;
    public TextMeshProUGUI messageText;
    public float speedIncreaseAmount = 3f;
    public int acornCost = 0;
    public GameObject upgradeMenu;

    private void Start()
    {
        if (playerController == null)
            playerController = GameObject.FindObjectOfType<PlayerController>(); // Check if player controller is assigned in the scene
        if (acornCollection == null)
            acornCollection = GameObject.FindObjectOfType<AcornCollection>(); // Check if acorn collection is assigned in the scene
    }

    public void TryBoostSpeed()
    {
        if (acornCollection != null && playerController != null)
        {
            if (acornCollection.Acorns >= acornCost) // Checks if the player has enough acorns
            {
                // Uses Acorns to buy upgrade
                acornCollection.UseAcorns(acornCost);
                playerController.IncreaseSpeed(speedIncreaseAmount);
            }
        }
    }
}