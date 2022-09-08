using UnityEngine;

public class DistanceJump : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    public void jump() {
        playerManager.Distance += 200;
    }
}
