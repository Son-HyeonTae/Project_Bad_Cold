using UnityEngine;

public class Pause : MonoBehaviour {
    [SerializeField]
    private GameObject pauseMenu;

    public void OnClick() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
