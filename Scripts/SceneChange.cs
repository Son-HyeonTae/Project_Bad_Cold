using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    public void SceneLoader(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}