using UnityEngine;

public class BonusBoxHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 50;
    [SerializeField]
    private float currentHP;

    private GameObject player;

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
