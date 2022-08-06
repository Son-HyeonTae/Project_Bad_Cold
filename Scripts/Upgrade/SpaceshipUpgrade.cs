using UnityEngine;

public class SpaceshipUpgrade : MonoBehaviour {
    [SerializeField]
    private GameObject spaceshipUpgrade;

    public void OnClick() {
        spaceshipUpgrade.SetActive(true);
    }
}
