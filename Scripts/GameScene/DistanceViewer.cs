using UnityEngine;
using TMPro;

public class DistanceViewer : MonoBehaviour {
    [SerializeField]
    private Player          player;

    private TextMeshProUGUI textDistance;

    private void Awake() {
        textDistance = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        textDistance.text = player.Distance + " meters";
    }
}
