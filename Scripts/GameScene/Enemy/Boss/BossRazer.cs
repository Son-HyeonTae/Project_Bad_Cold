using System.Collections;
using UnityEngine;

public class BossRazer : MonoBehaviour {
    [SerializeField]
    private int   damage      = 1;
    [SerializeField]
    private float attackTime  = 2.5f;
    [SerializeField]
    private float attackRange = 1.3f;

    private void OnEnable() {
        transform.localScale = new Vector3(0.2f, 13.3f, 1f);
        StartCoroutine("ChargeRazer");
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private IEnumerator ChargeRazer() {
        Color color = GetComponent<SpriteRenderer>().color;
        float green = 255;
        while(green >= 105f) {
            color = new Color(65f/255f, green/255f, 255f/255f);
            GetComponent<SpriteRenderer>().color = color;
            green -= 1.5f;
            yield return new WaitForSeconds(0.02f);
        }
        transform.localScale = new Vector3(attackRange, 13.3f, 1f);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
        }
    }
}