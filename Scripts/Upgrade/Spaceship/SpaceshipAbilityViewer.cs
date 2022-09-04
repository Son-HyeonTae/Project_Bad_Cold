using UnityEngine;
using TMPro;

public class SpaceshipAbilityViewer : MonoBehaviour {
    private TextMeshProUGUI spaceshipAbilityText;

    void Start() {
        spaceshipAbilityText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        spaceshipAbilityText.text = "Score + " + (GameManager.gameManager.SpaceshipLevel * 0.1f) + "%";
    }
}
