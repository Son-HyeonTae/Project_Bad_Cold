using UnityEngine;

public class ResourceMovement : MonoBehaviour {
    [SerializeField]
    private PlayerManager playerManager;

    public void ResourceMove() {
        GameManager.gameManager.Gold       += playerManager.playerGold;
        GameManager.gameManager.score[5]    = playerManager.playerScore;
        GameManager.gameManager.recentScore = playerManager.playerScore;
        GameManager.gameManager.SortScore();
    }
}
