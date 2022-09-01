using UnityEngine;
using UnityEngine.UI;

public class CallunaGuageViewer : MonoBehaviour {
    [SerializeField]
    private CallunaGuage callunaGuage;
    public  Image        guageImage;
    private float        currentValue;

    void Update() {
        guageImage.fillAmount = callunaGuage.guagePoint / 60.0f;
    }
}