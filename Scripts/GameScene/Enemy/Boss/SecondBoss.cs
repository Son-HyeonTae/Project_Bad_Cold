using System.Collections;
using UnityEngine;

public class SecondBoss : MonoBehaviour {
    [SerializeField]
    private StageData  stageData;
    [SerializeField]
    private float      brokenTime = 5.0f;

    private Movement2D movement2D;

    void Start() {
        movement2D = GetComponent<Movement2D>();
        GameObject.Find("Player").GetComponent<PlayerManager>().StopDistance();
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn() {
        movement2D.MoveTo(Vector3.down);
        yield return new WaitForSeconds(2f);
        movement2D.MoveTo(Vector3.zero);
        yield return new WaitForSeconds(2f);

        StartCoroutine("Phase01");
    }

    private IEnumerator Phase01() {
        transform.Find("RazerL").gameObject.SetActive(true);
        transform.Find("RazerR").gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        Vector3 direction = Vector3.right;
        movement2D.MoveTo(direction);

        while(transform.Find("BossShieldBlinder") != null) {
            if(transform.position.x >= 2.0f || transform.position.x <= -2.0f) {
                direction *= -1;
                movement2D.MoveTo(direction);
            }

            if (transform.Find("RazerL").gameObject.activeSelf == false) {
                StartCoroutine("CoolTime01");
            }

            yield return null;
        }

        transform.Find("RazerL").gameObject.SetActive(false);
        transform.Find("RazerR").gameObject.SetActive(false);
        StartCoroutine("Phase02");
        StopCoroutine("Phase01");
    }

    private IEnumerator CoolTime01() {
        yield return new WaitForSeconds(2.0f);
        transform.Find("RazerL").gameObject.SetActive(true);
        transform.Find("RazerR").gameObject.SetActive(true);
    }

    private IEnumerator Phase02() {
        movement2D.MoveTo(Vector3.zero);
        yield return new WaitForSeconds(brokenTime);

        transform.Find("RazerC").gameObject.SetActive(true);

        Vector3 direction = Vector3.right;
        movement2D.MoveTo(direction);

        while(true) {
            if(transform.position.x >= 1.0f || transform.position.x <= -1.0f) {
                direction *= -1;
                movement2D.MoveTo(direction);
            }
            
            if (transform.Find("RazerC").gameObject.activeSelf == false) {
                StartCoroutine("CoolTime02");
            }
            yield return null;
        }
    }

    private IEnumerator CoolTime02() {
        yield return new WaitForSeconds(2.0f);
        transform.Find("RazerC").gameObject.SetActive(true);
    }
}
