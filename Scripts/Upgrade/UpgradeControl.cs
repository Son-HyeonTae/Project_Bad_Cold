using UnityEngine;

public class UpgradeControl : MonoBehaviour {
    public void Upgrade() {
        GameManager.gameManager.WeaponLevel++;
    }

    public void Downgrade() {
        GameManager.gameManager.WeaponLevel--;
    }
}
