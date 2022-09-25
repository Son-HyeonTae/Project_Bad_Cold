using System.Collections;
using UnityEngine;

public class ApplicationQuitButton : MonoBehaviour {
    [SerializeField]
    private int        quitPercentage = 5;
    [SerializeField]
    private GameObject applicationQuitWindow;

    public void OnClick() {
        int randomNum = Random.Range(0, 100);
        
        if (randomNum < quitPercentage) {
            Application.Quit();
        }
        else {
            applicationQuitWindow.SetActive(false);
        }
    }
}
