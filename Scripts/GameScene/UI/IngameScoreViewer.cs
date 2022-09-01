using UnityEngine;
using TMPro;

public class IngameScoreViewer : MonoBehaviour {
    [SerializeField]
    private PlayerManager   playerManager;
    private TextMeshProUGUI playerScoreText;

    private void Awake() {
        playerScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        playerScoreText.text = playerManager.playerScore.ToString();
    }
}
