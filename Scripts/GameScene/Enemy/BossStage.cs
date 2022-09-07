using System.Collections;
using UnityEngine;

public class BossStage : MonoBehaviour {
    [SerializeField]
    private StageData     stageData;
    [SerializeField]
    private GameObject    firstBoss;
    [SerializeField]
    private GameObject    bossProjectile;
    [SerializeField]
    private PlayerManager playerManager;
    
    public void spawnfirstBoss() {
        playerManager.StopDistance();
        firstBoss = Instantiate(firstBoss, new Vector3(0, stageData.LimitMax.y + 2f, 0), Quaternion.identity);
        StartCoroutine("BossSpawn");
    }
    
    private IEnumerator BossSpawn() {
        firstBoss.GetComponent<Movement2D>().MoveTo(Vector3.down);
        yield return new WaitForSeconds(2f);
        firstBoss.GetComponent<Movement2D>().MoveTo(Vector3.zero);
        
        yield return new WaitForSeconds(3f);

        StartCoroutine("FanFire");
    }

    private IEnumerator FanFire() {
        int   count         = 30;
        float attackRate    = 0.1f;
        float intervalAngle = 360 / count;
        float weightAngle   = 0f;

        while(true) {
            for (int j = 0; j < 10; ++j) { // Count Projectile
                for (int i = 0; i < 5; ++i) { // Count Line
                    GameObject clone = Instantiate(bossProjectile, firstBoss.GetComponent<Transform>().position, Quaternion.identity);

                    float angle = 246 + intervalAngle * i;

                    float x = Mathf.Cos(angle * Mathf.PI / 180f);
                    float y = Mathf.Sin(angle * Mathf.PI / 180f);

                    clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
                }
                yield return new WaitForSeconds(attackRate); // Distance Between Projectiles
                if (j == 4) {
                    yield return new WaitForSeconds(0.5f);
                }
            }

            weightAngle = 0f;
            yield return new WaitForSeconds(2f);

            for (int j = 0; j < 15; ++j) { // Count Projectile
                for (int i = 0; i < 5; ++i) { // Count Line
                    GameObject clone = Instantiate(bossProjectile, firstBoss.GetComponent<Transform>().position, Quaternion.identity);

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
}