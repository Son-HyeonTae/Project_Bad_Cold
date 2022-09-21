using System.Collections;
using UnityEngine;

public class EnemyHP : MonoBehaviour {
    private GameObject player;

    // HP
    [SerializeField]
    private float maxHP = 5;
    [SerializeField]
    private float currentHP;

    // Points
    [SerializeField]
    private int   killScore = 5;
    [SerializeField]
    private int   killGold  = 1;

    // items
    // [0] - TimeSlow, [1] - DoubleCredit
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private int itemPercentage = 5;

    private void Awake() {
        currentHP = maxHP;
        player = GameObject.Find("Player");
    }

    public void TakeDamage(float damage) {
        currentHP -= damage;

        if (currentHP <= 0) {
            int randomItem = Random.Range(1, 101);
            if (randomItem <= itemPercentage) {
                StartCoroutine("ItemSpawn");
            }

            player.GetComponent<CallunaGuage>().guagePoint += 1;
            player.GetComponent<PlayerManager>().GetGold(killGold);
            player.GetComponent<PlayerManager>().GetKillScore(killScore);

            Destroy(gameObject);
        }
    }

    private void ItemSpawn() {
        int itemNum = Random.Range(0, 2);

        GameObject item = Instantiate(items[itemNum], transform.position, Quaternion.identity);
    }
}
