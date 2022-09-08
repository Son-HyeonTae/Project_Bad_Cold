using System.Collections;
using UnityEngine;

public class BossStage : MonoBehaviour {
    [SerializeField]
    private StageData     stageData;
    [SerializeField]
    private GameObject[]  BossPrefabs;
    [SerializeField]
    private GameObject    bossProjectile;
    [SerializeField]
    private PlayerManager playerManager;
    
    private GameObject    Boss;
    
    public void spawnBoss(int bossIndex) {
        playerManager.StopDistance();
        Boss = Instantiate(BossPrefabs[bossIndex], new Vector3(0, stageData.LimitMax.y + 2f, 0), Quaternion.identity);
        StartCoroutine("BossSpawn", bossIndex);
    }
    
    private IEnumerator BossSpawn(int bossIndex) {
        Boss.GetComponent<Movement2D>().MoveTo(Vector3.down);
        yield return new WaitForSeconds(2f);
        Boss.GetComponent<Movement2D>().MoveTo(Vector3.zero);
        yield return new WaitForSeconds(3f);

        if (bossIndex == 0) {
            StartCoroutine("FirstBossPattern");
        }
        else if (bossIndex == 1) {
            StartCoroutine("SecondBossPattern");
        }
    }

    private IEnumerator FirstBossPattern() {
        int   count         = 30;
        float weightAngle   = 0f;
        float intervalAngle = 360 / count;

        while(true) {
            for (int j = 0; j < 10; ++j) { // Count Projectile
                for (int i = 0; i < 5; ++i) { // Count Line
                    GameObject clone = Instantiate(bossProjectile, Boss.GetComponent<Transform>().position, Quaternion.identity);

                    float angle = 246 + intervalAngle * i;

                    float x = Mathf.Cos(angle * Mathf.PI / 180f);
                    float y = Mathf.Sin(angle * Mathf.PI / 180f);

                    clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
                }
                yield return new WaitForSeconds(0.1f); // Distance Between Projectiles
                if (j == 4) {
                    yield return new WaitForSeconds(0.5f);
                }
            }

            weightAngle = 0f;
            yield return new WaitForSeconds(2f);

            for (int j = 0; j < 15; ++j) { // Count Projectile
                for (int i = 0; i < 5; ++i) { // Count Line
                    GameObject clone = Instantiate(bossProjectile, Boss.GetComponent<Transform>().position, Quaternion.identity);

                    float angle = 246 + weightAngle + intervalAngle * i;

                    float x = Mathf.Cos(angle * Mathf.PI / 180f);
                    float y = Mathf.Sin(angle * Mathf.PI / 180f);

                    clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
                }
                weightAngle += 1.0f;
                yield return new WaitForSeconds(0.05f); // Distance Between Projectiles
                if ((j == 4)||(j == 9)) {
                    weightAngle = 0f;
                    yield return new WaitForSeconds(2f);
                }
            }

            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator SecondBossPattern() {
        yield return null;
    }
}