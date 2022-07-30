using UnityEngine;

public class Player : MonoBehaviour {
    private int distance;
    public  int Distance {
        set => distance = Mathf.Max(0, value);
        get => distance;
    }
}
