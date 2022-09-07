using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private StageData    stageData;
    [SerializeField]
    private GameObject   player;

    private Vector2      dragStartPos;
    private PlayerHP     playerHP;
    private Movement2D   movement2D;
    private PlayerWeapon playerWeapon;
    private CallunaGuage callunaGuage;

    private void Awake() {
        playerHP     = GetComponent<PlayerHP>();
        movement2D   = GetComponent<Movement2D>();
        playerWeapon = GetComponent<PlayerWeapon>();
        callunaGuage = GetComponent<CallunaGuage>();
    }

    private void Update() {
        if ((Input.touchCount > 0) && (Time.timeScale != 0)) {
            Touch   touch    = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = -3.7f;
            transform.position = Vector3.MoveTowards(transform.position, touchPosition, movement2D.moveSpeed);

            switch (touch.phase) {
                case TouchPhase.Began:
                    dragStartPos = touch.position;
                    playerWeapon.StartFiring();
                    break;
                case TouchPhase.Moved:
                    float movedPos = touch.position.y - dragStartPos.y;

                    if (callunaGuage.fullCharge && (Mathf.Abs(movedPos) > 500.0f)) {
                        if (movedPos > 0f) {
                            playerWeapon.ActivateCallunaAmplification();
                            callunaGuage.ResetCallunaGuage();
                        }
                        else if (movedPos < 0f) {
                            playerHP.ActivateCallunaGracePeriod();
                            callunaGuage.ResetCallunaGuage();
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    playerWeapon.StopFiring();
                break;
            }
        }
    }

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
