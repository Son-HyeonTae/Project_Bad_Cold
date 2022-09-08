using UnityEngine;
using TMPro;

public class BlinkTouchToStart : MonoBehaviour {
    private float time;

    void Update() {
        if (time < 0.3f) {
            GetComponent<TextMeshProUGUI>().color = new Color(0, 255, 0, 1 - time);
        }
        else {
            GetComponent<TextMeshProUGUI>().color = new Color(0, 255, 0, time);
            if (time > 1f) {
                time = 0;
            }
        }

        time += Time.deltaTime;
    }
}