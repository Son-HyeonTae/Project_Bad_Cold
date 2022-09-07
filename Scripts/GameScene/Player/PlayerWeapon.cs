using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float attackRate = 0.1f;
    [SerializeField]
    private float CallunaAmplificationTime = 10f;
    
    private bool  CallunaAmplificationFlag = false;

    public void ActivateCallunaAmplification() {
        StartCoroutine("CallunaAmplification");
    }

    private IEnumerator CallunaAmplification() {
        CallunaAmplificationFlag = true;
        yield return new WaitForSeconds(CallunaAmplificationTime);
        CallunaAmplificationFlag = false;
    }

    public void StartFiring() {
        StartCoroutine("TryAttack");
    }

    public void StopFiring() {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack() {
        while (true) {
            if (CallunaAmplificationFlag == true) {
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 0.1f, 0f) + Vector3.left * 0.3f, Quaternion.identity);
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 0.1f, 0f) + Vector3.right * 0.3f, Quaternion.identity);
            }
            else {
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 0.3f, 0f), Quaternion.identity);
            }

            yield return new WaitForSeconds(attackRate);
        }
    }
}
