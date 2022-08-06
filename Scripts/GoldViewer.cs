using UnityEngine;
using TMPro;

public class GoldViewer : MonoBehaviour {
    private TextMeshProUGUI textGold;

    private void Awake() {
        textGold = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        textGold.text = GameManager.instance.gold + "";
    }
}
