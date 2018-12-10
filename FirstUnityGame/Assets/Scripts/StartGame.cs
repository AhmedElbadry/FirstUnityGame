using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public void startGame()
    {
        FindObjectOfType<GameManager>().loadNextScene();
    }

}
