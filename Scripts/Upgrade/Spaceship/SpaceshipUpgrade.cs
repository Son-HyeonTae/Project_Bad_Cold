using UnityEngine;
using UnityEngine.UI;

public class SpaceshipUpgrade : MonoBehaviour {
    [SerializeField]
    private GameObject spaceshipUpgradeWindow;
    [SerializeField]
    private Button     spaceshipUpgradeButton;
    [SerializeField]
    private int        spaceshipUpgradeCost = 10;

    private void Update() {
        ColorBlock colorBlock = spaceshipUpgradeButton.colors;

        if (GameManager.gameManager.Gold < spaceshipUpgradeCost)
            colorBlock.pressedColor = Color.red;
        else 
            colorBlock.pressedColor = Color.green;
        spaceshipUpgradeButton.colors = colorBlock;
    }

    public void OnClick() {
        ColorBlock colorBlock = spaceshipUpgradeButton.colors;

        if (GameManager.gameManager.Gold < spaceshipUpgradeCost) {
            return;
        }
        else {
            GameManager.gameManager.SpendGold(spaceshipUpgradeCost);
            GameManager.gameManager.SpaceshipLevel += 1;
            spaceshipUpgradeWindow.SetActive(false);
        }
    }
}