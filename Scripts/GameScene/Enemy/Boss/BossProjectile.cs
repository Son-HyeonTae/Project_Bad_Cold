using UnityEngine;

public class BossProjectile : MonoBehaviour {
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (!(collision.GetComponent<PlayerHP>().callunaGracePeriodFlag)){
                collision.GetComponent<PlayerHP>().TakeDamage(damage);
                    
                Destroy(gameObject);
            }
        }
    }
}
