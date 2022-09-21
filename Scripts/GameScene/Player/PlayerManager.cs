using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField]
    private int distance;
    public  int Distance {
        set => distance = Mathf.Max(0, value);
        get => distance;
    }

    public int playerGold;
    public int playerScore;
    public int killScore;
    
    // flags
    public  bool moveFlag;
    private bool doubleCreditFlag;

    void Awake() {
        StartCoroutine("GoForward");
    }
    
    void Update() {
        playerScore = (int)(((distance * 0.01f) + killScore) +
                            ((distance * 0.01f) + killScore) * (GameManager.gameManager.SpaceshipLevel * 0.1f));
    }

    public void GoDistance() {
        StartCoroutine("GoForward");
        moveFlag = false;
    }

    public void StopDistance() {
        StopCoroutine("GoForward");
        moveFlag = true;
    }

    private IEnumerator GoForward() {
        while (true) {
            distance += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void GetGold(int gold) {
        if (doubleCreditFlag) {
            gold *= 2;
        }
        playerGold += gold;
    }

    public IEnumerator DoubleCreditItemActivate() {
        doubleCreditFlag = true;
        yield return new WaitForSeconds(10.0f);
        doubleCreditFlag = false;
    }

    public void GetKillScore(int score) {
        killScore += score;
    }

}