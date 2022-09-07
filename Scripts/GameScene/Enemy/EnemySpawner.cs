using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // GameData
    [SerializeField]
    private StageData     stageData;
    [SerializeField]
    private PlayerManager playerManager;
    [SerializeField]
    private BossStage     bossStage;

    // Prefabs
    [SerializeField]
    private GameObject[]  enemyPrefabs;
    [SerializeField]
    private GameObject    bonusBoxPrefab;
    [SerializeField]
    private GameObject    alartLinePrefab;
    [SerializeField]
    private GameObject    meteoritePrefab;

    // Spawn Percentage
    [SerializeField]
    private int  meteoriteSpawnPercentage = 25;
    [SerializeField]
    private int  bonusBoxSpawnPercentage = 5;
    
    // Flags
    private bool enemySpawnFlag;
    private bool bonusBoxSpawnFlag;

    private int  distance;
    private int  enemyType;
    private int  waveCount; // For Bonus Box

    private void Awake() {
        // WaveSpawn();
    }

    private void Update() {
        distance = playerManager.Distance;

        if (distance % 30f == 0 && !enemySpawnFlag) {
            WaveSpawn();
        }
        if (distance % 30f != 0) {
            enemySpawnFlag = false;
        }

        if (distance >= 500 ) enemyType = 1;
        if (distance >= 1500) enemyType = 2;
        if (distance >= 2500) enemyType = 3; 
        if (distance >= 4000) enemyType = 4;

        if (distance == 1000f && playerManager.moveFlag == false) {
            bossStage.spawnfirstBoss();
        }
    }

    private void WaveSpawn() {
        float positionX = stageData.LimitMin.x-0.07f; // aim to proper position

        int weakPoint = Random.Range(0, 6);

        for (int i = 0; i < 6; i++) {
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            if (i == weakPoint) {
                GameObject enemyClone = Instantiate(enemyPrefabs[Mathf.Clamp(enemyType - 1, 0, 4)], position, Quaternion.identity);
            }
            else {
                GameObject enemyClone = Instantiate(enemyPrefabs[enemyType], position, Quaternion.identity);
            }
            positionX += 0.95f;
        }

        enemySpawnFlag = true;
        
        //
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

        if (Random.Range(1, 101) <= meteoriteSpawnPercentage) {
            StartCoroutine("SpawnMeteorite");
        }
    }

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
}