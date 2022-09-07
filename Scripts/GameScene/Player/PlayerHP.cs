 using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject callunaGracePeriod;
    [SerializeField]
    private float callunaGracePeriodTime = 3f;

    //HP
    [SerializeField]
    private float          maxHP = 3;
    private float          currentHP;
    public  float          CurrentHP {
        set => currentHP = Mathf.Max(0, value);
        get => currentHP;
    }

    // Player State
    [HideInInspector]
    private State playerState = State.Normal;
    private enum State {
        Normal,
        Damaged
    }

    private SpriteRenderer spriteRenderer;
    public  bool           callunaGracePeriodFlag;

    private void Awake() {
        currentHP      = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage) {
        if (playerState == State.Normal) {
            playerState =  State.Damaged;
            currentHP   -= damage;

            StopCoroutine ("HitAnimation");
            StartCoroutine("HitAnimation");

            if (currentHP <= 0) {
                Time.timeScale = 0;
                gameOver.SetActive(true);
            }
        }
    }

    private IEnumerator HitAnimation() {
        Color playerColor = spriteRenderer.color;
        
        for(int i = 0; i < 3; i++) {
            playerColor.a -= 0.8f;
            spriteRenderer.color = playerColor;
            yield return new WaitForSeconds(0.1f);
            playerColor.a += 0.8f;
            spriteRenderer.color = playerColor;
            yield return new WaitForSeconds(0.1f);
        }

        playerColor.a        = 1f;
        spriteRenderer.color = playerColor;
        playerState          = State.Normal;
    }


    // Grace Period
    public void ActivateCallunaGracePeriod() {
        callunaGracePeriod.SetActive(true);
        StartCoroutine("CallunaGracePeriodCoroutine");
    }

    private IEnumerator CallunaGracePeriodCoroutine() {
        // playerState = State.Damaged;
        callunaGracePeriodFlag = true;
        yield return new WaitForSeconds(callunaGracePeriodTime);
        // playerState = State.Normal;
        callunaGracePeriodFlag = false;

        callunaGracePeriod.SetActive(false);
    }
}
