using UnityEngine;

public class UpgradeControl : MonoBehaviour {
    public void WeaponUpgrade() {
        GameManager.gameManager.WeaponLevel++;
    }

    public void WeaponDowngrade() {
        GameManager.gameManager.WeaponLevel--;
    }

    public void SpaceshipUpgrade() {
        GameManager.gameManager.SpaceshipLevel++;
    }

    public void SpaceshipDowngrade() {
        GameManager.gameManager.SpaceshipLevel--;
    }
}
