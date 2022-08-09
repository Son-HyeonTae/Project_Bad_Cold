using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    public void SceneLoader(string sceneName) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}