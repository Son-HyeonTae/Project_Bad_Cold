using UnityEngine;

public class ExitSpaceShipUpgrade : MonoBehaviour {
    [SerializeField]
    private GameObject upgradeMenu;
    
    public void OnClick() {
        upgradeMenu.SetActive(false);
    }
}
