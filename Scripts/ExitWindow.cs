using UnityEngine;

public class ExitWindow : MonoBehaviour {
    [SerializeField]
    private GameObject window;
    
    public void OnClick() {
        window.SetActive(false);
    }
}
