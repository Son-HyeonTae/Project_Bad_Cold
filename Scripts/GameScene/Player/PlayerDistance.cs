using System.Collections;
using UnityEngine;

public class PlayerDistance : MonoBehaviour {
    [SerializeField]
    private int speed = 1;
    [SerializeField]
    private int distance;
    public  int Distance {
        set => distance = Mathf.Max(0, value);
        get => distance;
    }
    
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
            distance += speed;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
