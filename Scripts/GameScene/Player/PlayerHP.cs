using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour {
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject callunaGracePeriod;
    [SerializeField]
    private float CallunaGracePeriodTime = 3f;
    [SerializeField]
    private float          maxHP = 3;
    private float          currentHP;
    public  float          CurrentHP {
        set => currentHP = Mathf.Max(0, value);
        get => currentHP;
    }
    private SpriteRenderer spriteRenderer;

    private enum State {
        Normal,
        Damaged
    }

    [HideInInspector]
    private State playerState = State.Normal;

    private void Awake() {
        currentHP      = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ActivateCallunaGracePeriod() {
        callunaGracePeriod.SetActive(true);
        StartCoroutine("CallunaGracePeriodCoroutine");
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

    private IEnumerator CallunaGracePeriodCoroutine() {
        playerState = State.Damaged;
        yield return new WaitForSeconds(CallunaGracePeriodTime);
        playerState = State.Normal;
        callunaGracePeriod.SetActive(false);
    }
}
