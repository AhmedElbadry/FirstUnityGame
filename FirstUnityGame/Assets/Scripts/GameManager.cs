
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameEnded = false;

    public float restartDelay = 2f;
    public float startNewLevelDelay = 2f;


    public GameObject completeLevelUI;


    void Start()
    {
        Debug.Log("sdsdsdf");
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("Game Over");
            Invoke("restart", restartDelay);
        }


    }

    public void completeLevel()
    {
        Debug.Log("asdasd");
        completeLevelUI.SetActive(true);
        Invoke("loadNextScene", startNewLevelDelay);
    }

    void restart()
    {
        //SceneManager.LoadScene("Level01");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameEnded = false;
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
