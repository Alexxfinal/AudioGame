using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

    public static uiManager current;

    public Text score;

    public GameObject pauseMenu;

    public GameObject controlsMenu;

    public GameObject songMenu;

    public Image timeBar;

    public SongManager songManager;
    public FollowMouse script;
    public ScoreCollider script2;

    private void Start()
    {
        current = this;
        showSongMenu();

    }

    public void showSongMenu()
    {
        songMenu.SetActive(true);
        script.enabled = false;
        script2.enabled = false;
        timeBar.gameObject.transform.parent.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
    }

    public void playThisSong(AudioSource song)
    {
        songMenu.SetActive(false);
        SongManager.current.SetSong(song);
        SongManager.current.playSong();
        script.enabled = true;
        script2.enabled = true;
        timeBar.gameObject.transform.parent.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            songManager.PauseSong();
            script.enabled = false;
            script2.enabled = false;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void updateScore(int newScore)
    {
        score.text = "Score: " + newScore.ToString();
    }

    public void showControlsMenu()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void showPauseMenu()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        songManager.UnPauseSong();
        script.enabled = true;
        script2.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void updateTimeBar(float newFill)
    {
        timeBar.fillAmount = newFill;
    }
}
