using UnityEngine;

public class ApplicationQuit : MonoBehaviour {
    [SerializeField]
    private GameObject applicationQuitWindow;
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            applicationQuitWindow.SetActive(true);
        }
    }
}
