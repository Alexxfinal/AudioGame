using UnityEngine.SceneManagement;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public static gameManager manager;

    private void Start()
    {
        manager = this;
        Application.targetFrameRate = 60;
    }

    public void resetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void getMeOut()
    {
        Application.Quit();
    }
}
