using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject cutScene;

    public static GameController instancia = null;

    private void Awake() {
        if (instancia == null) {
            instancia = this;
        }
        else if (instancia != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void TrPlayCutScene() {
        menuPanel.SetActive(false);
        Instantiate(cutScene);
    }

    public void TriFinishCutScene() {
        menuPanel.SetActive(true);
    }
}