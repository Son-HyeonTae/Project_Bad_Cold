using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private StageData    stageData;
    [SerializeField]
    private KeyCode      keyCodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode      keyCodeCallnunaGracePeriod = KeyCode.DownArrow;
    [SerializeField]
    private KeyCode      keyCodeCallnunaAmplification = KeyCode.UpArrow;

    private PlayerHP     playerHP;
    private Movement2D   movement2D;
    private PlayerWeapon playerWeapon;

    private void Awake() {
        playerHP     = GetComponent<PlayerHP>();
        movement2D   = GetComponent<Movement2D>();
        playerWeapon = GetComponent<PlayerWeapon>();
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

        if (Input.GetKeyDown(keyCodeCallnunaGracePeriod)) {
            playerHP.ActivateCallunaGracePeriod();
        }
        
        if (Input.GetKeyDown(keyCodeCallnunaAmplification)) {
            playerWeapon.ActivateCallunaAmplification();
        }
    }

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
