using UnityEngine;
using TMPro;

public class DistanceViewer : MonoBehaviour {
    [SerializeField]
    private PlayerDistance  playerDistance;
    private TextMeshProUGUI textDistance;

    private void Awake() {
        textDistance = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        textDistance.text = playerDistance.Distance + " meters";
    }
}
