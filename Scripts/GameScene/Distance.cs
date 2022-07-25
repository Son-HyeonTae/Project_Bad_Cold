using System.Collections;
using UnityEngine;

public class Distance : MonoBehaviour {
    [SerializeField]
    private int speed = 1;
    
    private void Awake() {
        StartCoroutine("GoForward");
    }

    public void Go() {
        StartCoroutine("GoForward");
    }

    public void Stop() {
        StopCoroutine("GoForward");
    }

    private IEnumerator GoForward() {
        while (true) {
            GetComponent<Player>().Distance += speed;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
