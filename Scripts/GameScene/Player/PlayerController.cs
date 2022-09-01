using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private StageData    stageData;
    [SerializeField]
    private KeyCode      keyCodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode      keyCodeCallunaGracePeriod = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode      keyCodeCallunaAmplification = KeyCode.UpArrow;

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
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.MoveTo(new Vector3(x, 0, 0));

        if (Input.GetKeyDown(keyCodeAttack)) {
            playerWeapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack)) {
            playerWeapon.StopFiring();
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

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
