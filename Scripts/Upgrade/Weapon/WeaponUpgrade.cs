using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgrade : MonoBehaviour {
    [SerializeField]
    private GameObject weaponUpgradeWindow;
    [SerializeField]
    private Button     weaponUpgradeButton;
    [SerializeField]
    private int        weaponUpgradeCost = 10;

    private void Update() {
        ColorBlock colorBlock = weaponUpgradeButton.colors;

        if (GameManager.gameManager.Gold < weaponUpgradeCost)
            colorBlock.pressedColor = Color.red;
        else 
            colorBlock.pressedColor = Color.green;
        weaponUpgradeButton.colors = colorBlock;
    }

    public void OnClick() {
        ColorBlock colorBlock = weaponUpgradeButton.colors;

        if (GameManager.gameManager.Gold < weaponUpgradeCost) {
            return;
        }
        else {
            GameManager.gameManager.SpendGold(weaponUpgradeCost);
            GameManager.gameManager.WeaponLevel += 1;
            weaponUpgradeWindow.SetActive(false);
        }
    }
}