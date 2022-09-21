using System.Collections;
using UnityEngine;

public class BossStage : MonoBehaviour {
    [SerializeField]
    private StageData     stageData;
    [SerializeField]
    private GameObject[]  bossPrefabs;
    
    public void spawnBoss(int bossIndex) {
        Instantiate(bossPrefabs[bossIndex], new Vector3(0, stageData.LimitMax.y + 2f, 0), Quaternion.identity);
    }
}