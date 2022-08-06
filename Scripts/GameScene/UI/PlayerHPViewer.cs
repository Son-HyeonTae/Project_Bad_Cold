using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour {
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;

    void Update() {
        foreach (Image image in hearts) {
            image.sprite = emptyHeart;
        }
        for (int i = 0; i < playerHP.CurrentHP; i++) {
            hearts[i].sprite = fullHeart;
        }
    }
}
