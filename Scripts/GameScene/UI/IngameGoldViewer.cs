using UnityEngine;
using TMPro;

public class IngameGoldViewer : MonoBehaviour {
    [SerializeField]
    private PlayerManager   playerManager;
    private TextMeshProUGUI playerGoldText;

    private void Awake() {
        playerGoldText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        playerGoldText.text = playerManager.playerGold.ToString();
    }
}
