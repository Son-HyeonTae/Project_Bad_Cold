using UnityEngine;

public class BossHP : MonoBehaviour {
    private GameObject player;
    
    [SerializeField]
    private float maxHP = 50;
    [SerializeField]
    private float currentHP;
    // [SerializeField]
    // private int   killScore = 5;
    // [SerializeField]
    // private int   killGold = 1;


    private void Awake() {
        currentHP = maxHP;
        player    = GameObject.Find("Player");
    }

    public void TakeDamage(float damage) {
        currentHP -= damage;

        if (currentHP <= 0) {
            player.GetComponent<PlayerManager>().GoDistance();
            Destroy(gameObject);
        }
        // player.GetComponent<PlayerManager>().playerGold += killGold;
        // player.GetComponent<PlayerManager>().killScore  += killScore;
        // player.GetComponent<CallunaGuage>().guagePoint  += 1;
    }
}
