using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private StageData    stageData;
    [SerializeField]
    private KeyCode      keyCodeCallunaGracePeriod = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode      keyCodeCallunaAmplification = KeyCode.UpArrow;
    [SerializeField]
    private GameObject   player;

    private PlayerHP     playerHP;
    private Movement2D   movement2D;
    private PlayerWeapon playerWeapon;
    private CallunaGuage callunaGuage;

    private bool isAttack;

    private void Awake() {
        playerHP     = GetComponent<PlayerHP>();
        movement2D   = GetComponent<Movement2D>();
        playerWeapon = GetComponent<PlayerWeapon>();
        callunaGuage = GetComponent<CallunaGuage>();
    }

    private void Update() {
        if (Time.timeScale != 0) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.y = -3.7f;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, movement2D.moveSpeed);
                // transform.position = touchPosition;

                if (Input.GetMouseButtonDown(0)) {
                    playerWeapon.StartFiring();
                }
                else if(Input.GetMouseButtonUp(0)) {
                    playerWeapon.StopFiring();
                }
            }
        

            if (Input.GetKeyDown(keyCodeCallunaGracePeriod)   && callunaGuage.fullCharge) {
                playerHP.ActivateCallunaGracePeriod();
                callunaGuage.ResetCallunaGuage();
            }
            
            if (Input.GetKeyDown(keyCodeCallunaAmplification) && callunaGuage.fullCharge) {
                playerWeapon.ActivateCallunaAmplification();
                callunaGuage.ResetCallunaGuage();
            }
        }
    }

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
