using UnityEngine;

public class WeaponUpgrade : MonoBehaviour {
    [SerializeField]
    private GameObject weaponUpgrade;

    public void OnClick() {
        weaponUpgrade.SetActive(true);
    }
}
