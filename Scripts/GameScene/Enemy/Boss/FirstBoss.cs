using System.Collections;
using UnityEngine;

public class FirstBoss : MonoBehaviour {
    [SerializeField]
    private GameObject bossProjectile;

    private Movement2D movement2D;

    void Start() {
        GameObject.Find("Player").GetComponent<PlayerManager>().StopDistance();
        movement2D = GetComponent<Movement2D>();
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn() {
        movement2D.MoveTo(Vector3.down);
        yield return new WaitForSeconds(2f);
        movement2D.MoveTo(Vector3.zero);
        yield return new WaitForSeconds(3f);

        StartCoroutine("Pattern");
    }

    private IEnumerator Pattern() {
        int   count         = 30;
        float weightAngle   = 0f;
        float intervalAngle = 360 / count;

        while(true) {
            for (int j = 0; j < 10; ++j) { // Count Projectile
                for (int i = 0; i < 5; ++i) { // Count Line
                    GameObject clone = Instantiate(bossProjectile, transform.position, Quaternion.identity);

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
                    GameObject clone = Instantiate(bossProjectile, transform.position, Quaternion.identity);

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
