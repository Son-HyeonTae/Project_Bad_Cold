using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // GameData
    [SerializeField]
    private StageData     stageData;
    [SerializeField]
    private BossStage     bossStage;
    [SerializeField]
    private PlayerManager playerManager;

    // Prefabs
    [SerializeField]
    private GameObject[]  enemyPrefabs;
    [SerializeField]
    private GameObject    bonusBoxPrefab;
    [SerializeField]
    private GameObject    alartLinePrefab;
    [SerializeField]
    private GameObject    meteoritePrefab;
    [SerializeField]
    private GameObject    timeSlowBackgroundPrefab;

    // Spawn Percentage
    [SerializeField]
    private int   meteoriteSpawnPercentage = 25;
    [SerializeField]
    private int   bonusBoxSpawnPercentage  = 5;
    
    // Flags
    private bool  timeSlowFlag;
    private bool  enemySpawnFlag;
    private bool  bonusBoxSpawnFlag;

    private int   distance;
    private int   enemyType;
    private int   waveCount; // For Bonus Box
    private float enemyMoveSpeed     = 4f;  // For Time Slow Item;
    private float enemySpawnDistance = 30f; // For Time Slow Item;

    private void Awake() {
        // WaveSpawn();
    }

    private void Update() {
        distance = playerManager.Distance;

        // Enemy Spawn
        if (distance % enemySpawnDistance == 0 && !enemySpawnFlag) {
            WaveSpawn();
        }
        if (distance % enemySpawnDistance != 0) {
            enemySpawnFlag = false;
        }

        // Enemy Level
        if (distance >= 500 ) enemyType = 1;
        if (distance >= 1500) enemyType = 2;
        if (distance >= 2500) enemyType = 3; 
        if (distance >= 4000) enemyType = 4;

        if (distance == 1000f && playerManager.moveFlag == false) {
            bossStage.spawnBoss(0); // First Boss
        }
        if (distance == 2999f && playerManager.moveFlag == false) {
            bossStage.spawnBoss(1); // Second Boss
        }
    }

    private void WaveSpawn() {
        float positionX = stageData.LimitMin.x - 0.07f; // Aim to Proper Position

        int weakPoint = Random.Range(0, 6);

        for (int i = 0; i < 6; i++) {
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            if (i == weakPoint) {
                GameObject enemyClone = Instantiate(enemyPrefabs[Mathf.Clamp(enemyType - 1, 0, 4)], position, Quaternion.identity);
                enemyClone.GetComponent<Movement2D>().moveSpeed = enemyMoveSpeed;
            }
            else {
                GameObject enemyClone = Instantiate(enemyPrefabs[enemyType], position, Quaternion.identity);
                enemyClone.GetComponent<Movement2D>().moveSpeed = enemyMoveSpeed;
            }
            positionX += 0.95f;
        }
        enemySpawnFlag = true;
        
        // BonusBox
        if ((Random.Range(1, 101) <= bonusBoxSpawnPercentage) && (distance >= 1000m) && (!bonusBoxSpawnFlag)) {
            bonusBoxSpawnFlag = true;
            StartCoroutine("SpawnBonusBox");
        }
        if (bonusBoxSpawnFlag) {
            waveCount++;
            if (waveCount >= 5) {
            waveCount         = 0;
            bonusBoxSpawnFlag = false;
            Destroy(GameObject.FindWithTag("BonusBox"));
            }
        }

        // Meteorite
        if (Random.Range(1, 101) <= meteoriteSpawnPercentage) {
            StartCoroutine("SpawnMeteorite");
        }
    }

    // Coroutines
    private IEnumerator SpawnBonusBox() {
        yield return new WaitForSeconds(0.5f);
        GameObject bonusBox = Instantiate(bonusBoxPrefab, new Vector3(0, stageData.LimitMax.y + 1.0f, 0), Quaternion.identity);
    }

    private IEnumerator SpawnMeteorite() {
        int randomLine = Random.Range(0, 6);
        GameObject alartLine = Instantiate(alartLinePrefab, new Vector3(-2.37f+(0.95f * randomLine), 0, 0), Quaternion.identity);

        yield return new WaitForSeconds(2.5f);

        Destroy(alartLine);

        Instantiate(meteoritePrefab, new Vector3(-2.37f+(0.95f * randomLine), stageData.LimitMax.y + 1.0f, 0), Quaternion.identity);
    }

    public IEnumerator TimeSlowItemActivate() {
        GameObject background = Instantiate(timeSlowBackgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemySpawnDistance = 60f;
        enemyMoveSpeed = 2f;
        yield return new WaitForSeconds(10f);
        enemySpawnDistance = 30f;
        enemyMoveSpeed = 4f;
        Destroy(background);
    }
}