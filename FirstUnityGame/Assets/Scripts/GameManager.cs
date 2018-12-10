
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameEnded = false;

    public float restartDelay = 2f;

    public GameObject completeLevelUI;

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
    }
    void restart()
    {
        //SceneManager.LoadScene("Level01");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameEnded = false;
    }


}
