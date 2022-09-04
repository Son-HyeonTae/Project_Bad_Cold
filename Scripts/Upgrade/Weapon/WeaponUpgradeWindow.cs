using UnityEngine;

public class WeaponUpgradeWindow : MonoBehaviour {
    [SerializeField]
    private GameObject weaponUpgradeWindow;

    public void OnClick() {
        weaponUpgradeWindow.SetActive(true);
    }
}
