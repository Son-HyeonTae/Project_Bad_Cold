using UnityEngine;

public class EnemyHP : MonoBehaviour {
    [SerializeField]
    private float maxHP = 5;
    [SerializeField]
    private int gold = 1;
    private float currentHP;

    private void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage) {
        currentHP -= damage;

        if (currentHP <= 0) {
            Destroy(gameObject);

            GameManager.instance.getGold(gold);
        }
    }
}
