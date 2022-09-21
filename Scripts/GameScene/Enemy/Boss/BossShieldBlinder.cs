using UnityEngine;

public class BossShieldBlinder : MonoBehaviour {
    [SerializeField]
    private GameObject ShieldL;
    [SerializeField]
    private GameObject ShieldR;

    void Update() {
        if ((ShieldL == null) && (ShieldR == null)) {
            Destroy(gameObject);
        }
    }
}
