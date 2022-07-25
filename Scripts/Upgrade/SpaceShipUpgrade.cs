using UnityEngine;

public class SpaceShipUpgrade : MonoBehaviour {
    [SerializeField]
    private GameObject spaceShipUpgrade;

    public void OnClick() {
        spaceShipUpgrade.SetActive(true);
    }
}
