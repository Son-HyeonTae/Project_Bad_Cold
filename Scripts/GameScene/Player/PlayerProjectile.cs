using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Boss")) {
            collision.GetComponent<BossHP>().TakeDamage(GameManager.gameManager.WeaponLevel);

            Destroy(gameObject);
        }

        if (collision.CompareTag("BossShield")) {
            collision.GetComponent<BossShieldHP>().TakeDamage(GameManager.gameManager.WeaponLevel);

            Destroy(gameObject);
        }

        if (collision.CompareTag("BossShieldBlinder")) {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<EnemyHP>().TakeDamage(GameManager.gameManager.WeaponLevel);

            Destroy(gameObject);
        }

        if (collision.CompareTag("BonusBox")) {
            collision.GetComponent<BonusBoxHP>().TakeDamage(GameManager.gameManager.WeaponLevel);

            Destroy(gameObject);
        }
        
    }
}
