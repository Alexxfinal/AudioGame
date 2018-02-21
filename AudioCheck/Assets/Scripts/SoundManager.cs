using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager current;

    public AudioSource hitSound;

	void Start ()
    {
        current = this;	
	}

    public void playHitSound()
    {
        hitSound.Play();
    }

    public void changeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
    }
}
