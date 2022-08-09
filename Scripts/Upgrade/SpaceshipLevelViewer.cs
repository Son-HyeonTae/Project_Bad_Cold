using UnityEngine;
using TMPro;

public class SpaceshipLevelViewer : MonoBehaviour {
    private TextMeshProUGUI spaceshipLevelText;

    private void Awake() {
        spaceshipLevelText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        spaceshipLevelText.text = "Spaceship\nLv " + GameManager.gameManager.SpaceshipLevel;
    }
}
