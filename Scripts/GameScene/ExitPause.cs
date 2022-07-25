using UnityEngine;

public class ExitPause : MonoBehaviour {
    [SerializeField]
    private GameObject pauseMenu;
    
    public void OnClick() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
