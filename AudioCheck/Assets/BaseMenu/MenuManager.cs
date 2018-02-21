using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Animator introObject;

    public Animator menuObject;

    public float transitionTime = 1f;

	IEnumerator Start ()
    {
        yield return StartCoroutine(playFadeTransition(introObject, "fadeIn", transitionTime));

        yield return new WaitForSeconds(transitionTime + 0.5f);

        yield return StartCoroutine(playFadeTransition(introObject, "fadeOut", transitionTime));

        yield return new WaitForSeconds(transitionTime + 0.5f);

        introObject.gameObject.SetActive(false);
        menuObject.gameObject.SetActive(true);

        yield return StartCoroutine(playFadeTransition(menuObject, "menu@fadeIn", transitionTime));
    }

    IEnumerator playFadeTransition(Animator player, string animationName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        player.Play(animationName, 0);
    }

    public void loadSceneButtonWrapper(string newScene)
    {
		StartCoroutine(loadScene(newScene));
    }

	private IEnumerator loadScene(string newScene)
	{
		yield return new WaitForSeconds(transitionTime + 0.5f);
		SceneManager.LoadScene(newScene);
	}

	public void quitGameButtonWrapper()
	{
		StartCoroutine(quitGame());
	}

	private IEnumerator quitGame()
	{
		yield return new WaitForSeconds(transitionTime * 1.5f);
		Application.Quit();
	}
}
