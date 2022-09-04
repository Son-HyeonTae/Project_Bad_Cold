using UnityEngine;

public class SpaceshipUpgradeWindow : MonoBehaviour {
    [SerializeField]
    private GameObject spaceshipUpgradeWindow;

    public void OnClick() {
        spaceshipUpgradeWindow.SetActive(true);
    }
}
