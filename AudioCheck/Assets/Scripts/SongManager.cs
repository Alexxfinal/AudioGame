using UnityEngine;

public class SongManager : MonoBehaviour {

    public AudioSource song;

    public static SongManager current;

    float currentTime = 0;

    public void Start()
    {
        current = this;
    }

    public void playSong()
    {
        song.Play();
    }

    public void PauseSong()
    {
        song.Pause();
    }

    public void SetSong(AudioSource newSong)
    {
        newSong.gameObject.SetActive(true);
        song = newSong;
    }

    public void UnPauseSong()
    {
        song.UnPause();
    }

    public void Update()
    {
        if (song.isPlaying)
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= song.clip.length)
        {
            uiManager.current.showSongMenu();
            currentTime = 0;
        } 
    }
}
