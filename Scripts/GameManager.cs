using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private int weaponLevel = 1;
    public  int WeaponLevel {
        set => weaponLevel = Mathf.Clamp(value,       1, 100);
        get => weaponLevel = Mathf.Clamp(weaponLevel, 1, 100);
    }

    [SerializeField]
    private int spaceshipLevel = 1;
    public  int SpaceshipLevel {
        set => spaceshipLevel = Mathf.Clamp(value,          1, 100);
        get => spaceshipLevel = Mathf.Clamp(spaceshipLevel, 1, 100);
    }

    [SerializeField]
    private int gold = 0;
    public  int Gold {
        set => gold = Mathf.Clamp(value, 0, 10000);
        get => gold = Mathf.Clamp(gold,  0, 10000);
    }

    public static GameManager gameManager;

    private void Awake() {
        if (gameManager == null) {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        else {
            Destroy(this);
        }
    }

    public void SpendGold(int upgradeCost) {
        StartCoroutine(ReduceGold(upgradeCost));
    }

    private IEnumerator ReduceGold(int upgradeCost) {

        for (int i = 0; i < upgradeCost; i++) {
            GameManager.gameManager.gold--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
