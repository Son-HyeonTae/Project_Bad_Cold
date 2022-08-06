using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private PlayerDistance playerDistance;

    private int enemyType = 0;
    private bool spawnFlag = true;

    private void Awake() {
        WaveSpawn();
    }

    private void Update() {
        if (playerDistance.Distance % 30f == 0 && spawnFlag == true)
            WaveSpawn();
        if (playerDistance.Distance % 30f != 0) spawnFlag = true;

        if (playerDistance.Distance >= 500 )    enemyType = 1;
        if (playerDistance.Distance >= 1000)    enemyType = 2;
        if (playerDistance.Distance >= 2000)    enemyType = 3; 
        if (playerDistance.Distance >= 4000)    enemyType = 4;
    }

    private void WaveSpawn() {
        float positionX = stageData.LimitMin.x-0.07f;

        for (int i = 0; i < 6; i++) {
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            GameObject enemyClone = Instantiate(enemyPrefabs[enemyType], position, Quaternion.identity);
            positionX += 0.95f;
        }

        spawnFlag = false;
    }
}