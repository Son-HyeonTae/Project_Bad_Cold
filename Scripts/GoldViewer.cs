using UnityEngine;
using TMPro;

public class GoldViewer : MonoBehaviour {
    private TextMeshProUGUI goldText;

    private void Awake() {
        goldText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        goldText.text = GameManager.gameManager.Gold.ToString();
    }
}
