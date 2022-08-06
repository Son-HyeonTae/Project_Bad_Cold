using UnityEngine;

public class Setting : MonoBehaviour {
    [SerializeField]
    private GameObject settingMenu;

    public void OnClick() {
        settingMenu.SetActive(true);
    }
}
