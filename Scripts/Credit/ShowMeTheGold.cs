using UnityEngine;

public class ShowMeTheGold : MonoBehaviour
{   
    private int click = 0;

    public void OnClick() {
        click++;

        if (click % 3 == 0) {
            GameManager.gameManager.Gold +=50;
        }
    }
}
