using UnityEngine;

public class ScoreCollider : MonoBehaviour {

    float score = 0;
    float scoreMultiplier = 0;

    public static ScoreCollider manager;

    private void Start()
    {
        manager = this;
    }

    private void Update()
    {
        if (scoreMultiplier < 0.31f)
            scoreMultiplier += Time.deltaTime * 1/60;

        score += 1 * scoreMultiplier;
        uiManager.current.updateScore((int)score);
    }

    public void resetScoreMultiplier()
    {
        scoreMultiplier = 0;
    }

    public void tookAHit()
    {
        score -= 5f;
    }

    public void usedShield()
    {
        score -= 2.5f;
    }
}
