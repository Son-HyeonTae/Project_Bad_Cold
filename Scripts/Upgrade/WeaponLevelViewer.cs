using UnityEngine;
using TMPro;

public class WeaponLevelViewer : MonoBehaviour {
    private TextMeshProUGUI weaponLevelText;

    private void Awake() {
        weaponLevelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        weaponLevelText.text = "Weapon\nLv. " + GameManager.gameManager.WeaponLevel;
    }
}
