using UnityEngine;
using TMPro;

public class WeaponAbilityViewer : MonoBehaviour {
    private TextMeshProUGUI weaponAbilityText;

    void Start() {
        weaponAbilityText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        weaponAbilityText.text = "Offence " + GameManager.gameManager.WeaponLevel;
    }
}
