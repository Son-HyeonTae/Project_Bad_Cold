using System.Collections;
using UnityEngine;

public class BossStage : MonoBehaviour {
    [SerializeField]
    private StageData     stageData;
    [SerializeField]
    private PlayerManager playerManager;

    [SerializeField]
    private GameObject    firstBoss;
    
    public void spawnfirstBoss() {
        playerManager.StopDistance();
        firstBoss = Instantiate(firstBoss, new Vector3(0, stageData.LimitMax.y + 2f, 0), Quaternion.identity);
        StartCoroutine("BossSpawn");
    }
    
    private IEnumerator BossSpawn() {
        firstBoss.GetComponent<Movement2D>().MoveTo(Vector3.down);
        yield return new WaitForSeconds(2f);
        firstBoss.GetComponent<Movement2D>().MoveTo(Vector3.zero);
        
        yield return null;
    }
}
