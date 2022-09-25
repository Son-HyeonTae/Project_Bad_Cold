using UnityEngine;

public class MapScroller : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3   moveDirection = Vector3.down;
    [SerializeField]
    private float     scrollRange   = 10.0f;
    [SerializeField]
    private float     moveSpeed     = 3.0f;

    private void Update() {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y <= -scrollRange) {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}