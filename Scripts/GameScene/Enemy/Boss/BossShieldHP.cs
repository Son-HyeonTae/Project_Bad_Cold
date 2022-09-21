using UnityEngine;

public class BossShieldHP : MonoBehaviour {
    
    [SerializeField]
    private float maxHP = 1500;
    [SerializeField]
    private float currentHP;
    // [SerializeField]
    // private int   killScore = 5;
    // [SerializeField]
    // private int   killGold = 1;


    private void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage) {
        currentHP -= damage;
        if (currentHP <= 0) {
            Destroy(gameObject);
        }
    }
}
