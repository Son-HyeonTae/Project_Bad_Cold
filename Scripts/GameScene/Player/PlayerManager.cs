using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public int playerGold;
    public int playerScore;
    public int killScore;

    [SerializeField]
    private int distance;
    public  int Distance {
        set => distance = Mathf.Max(0, value);
        get => distance;
    }

    private void Awake() {
        StartCoroutine("GoForward");
    }
    
    void Update() {
        playerScore = (int)(((distance * 0.01f) + killScore) +
                            ((distance * 0.01f) + killScore) * (GameManager.gameManager.SpaceshipLevel * 0.1f));
    }

    // public void Go() {
    //     StartCoroutine("GoForward");
    // }

    // public void Stop() {
    //     StopCoroutine("GoForward");
    // }

    private IEnumerator GoForward() {
        while (true) {
            distance += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
