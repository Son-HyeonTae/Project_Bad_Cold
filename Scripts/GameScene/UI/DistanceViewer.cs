using UnityEngine;
using TMPro;

public class DistanceViewer : MonoBehaviour {
    [SerializeField]
    private PlayerManager   playerManager;
    private TextMeshProUGUI textDistance;

    private void Awake() {
        textDistance = GetComponent<TextMeshProUGUI>();
    }   

    private void Update() {
        textDistance.text = playerManager.Distance + " meters";
    }
}
