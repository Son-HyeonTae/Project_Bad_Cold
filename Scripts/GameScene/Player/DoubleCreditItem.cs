using System.Collections;
using UnityEngine;

public class DoubleCreditItem : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerManager>().StartCoroutine("DoubleCreditItemActivate");
            Destroy(gameObject);
        }
    }
}
