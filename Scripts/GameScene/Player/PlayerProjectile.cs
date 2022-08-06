using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    [SerializeField]
    private float damage = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<EnemyHP>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
