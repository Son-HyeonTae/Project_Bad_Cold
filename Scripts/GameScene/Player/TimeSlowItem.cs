using System.Collections;
using UnityEngine;

public class TimeSlowItem : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().StartCoroutine("TimeSlowItemActivate");

            Destroy(gameObject);
        }
    }
}
