using UnityEngine;
using TMPro;

public class ScoreViewer : MonoBehaviour {
    private TextMeshProUGUI scoreText;

    private void Awake() {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        scoreText.text = GameManager.gameManager.score[int.Parse(this.gameObject.name)].ToString();
    }
}
