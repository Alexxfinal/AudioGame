using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public GameObject shot;
    public GameObject shield;

    public float invincibilityTimerMax = 2f;
    float currentFrameInvincibility = 0;

    public float maxSlowdownTime = 2f;
    public float growthRate = 0.05f;

    public float currentSlowTime;

    public Animator player;

    private void Start()
    {
        currentSlowTime = maxSlowdownTime;
    }

    void Update ()
    {
        //transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;

        position.x = Mathf.Clamp(position.x, Camera.main.transform.position.x - Camera.main.orthographicSize - 1f, Camera.main.transform.position.x + Camera.main.orthographicSize + 1f);

        transform.position = position;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newShot = Instantiate(shot);
            newShot.transform.position = transform.position;
            newShot.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            ScoreCollider.manager.resetScoreMultiplier();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject newShield = Instantiate(shield);
            newShield.transform.position = transform.position;
            ScoreCollider.manager.resetScoreMultiplier();
            ScoreCollider.manager.usedShield();
        }

        if (Input.GetMouseButtonDown(2))
        {
            Time.timeScale = 0.6f;
        }

        if (currentFrameInvincibility > 0)
            currentFrameInvincibility -= Time.deltaTime;

        if (Time.timeScale < 1)
        {
            currentSlowTime -= growthRate * 1.5f;
        }
        else if (currentSlowTime < maxSlowdownTime)
        {
            currentSlowTime += growthRate;
        }

        uiManager.current.updateTimeBar(currentSlowTime / maxSlowdownTime);

        if (currentSlowTime <= 0)
        {
            Time.timeScale = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Note" && currentFrameInvincibility <= 0)
        {
            iWasHit();
            ScoreCollider.manager.resetScoreMultiplier();
        }
    }

    private void iWasHit()
    {
        player.Play("player_hit");
        currentFrameInvincibility = invincibilityTimerMax;
        ScoreCollider.manager.tookAHit();
        SoundManager.current.playHitSound();
    }
}
