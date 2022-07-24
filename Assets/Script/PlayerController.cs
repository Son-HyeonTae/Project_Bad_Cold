using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private StageData  stageData;
    private Movement2D movement2D;

    private void Awake() {
        movement2D = GetComponent<Movement2D>();
    }

    private void Update() {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.MoveTo(new Vector3(x, 0, 0));
    }

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
