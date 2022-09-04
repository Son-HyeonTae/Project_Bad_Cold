using UnityEngine;
using TMPro;

public class RecentScoreViewer : MonoBehaviour {
    private TextMeshProUGUI recentScoreText;

    private void Awake() {
        recentScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        recentScoreText.text = GameManager.gameManager.recentScore.ToString();
    }
}
