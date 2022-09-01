using UnityEngine;

public class CallunaGuage : MonoBehaviour {
    public int  guagePoint = 0;
    public bool fullCharge;

    void Update()
    {
        if (guagePoint >= 60) {
            fullCharge = true;
            guagePoint = 60;
        }
    }

    public void ResetCallunaGuage() {
        guagePoint = 0;
        fullCharge = false;
    }
}
