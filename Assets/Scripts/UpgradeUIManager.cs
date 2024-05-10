using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{
    public GameObject upgradePanel;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.U)) // Checks if the U key is pressed on the keyboard
        {
            ShowUpgradeUI(true);
        }
        else if (Input.GetKeyUp(KeyCode.U)) // Checks to see if the U key is released on the keyboard
        {
            ShowUpgradeUI(false);
        }
    }

// Makes the upgrade screen visible when the U key is pressed on the keyboard
    private void ShowUpgradeUI(bool isVisible)
    {
        if (upgradePanel != null)
        {
            upgradePanel.SetActive(isVisible);
    }
}
}
