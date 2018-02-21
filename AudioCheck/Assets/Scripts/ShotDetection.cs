using UnityEngine;

public class ShotDetection : MonoBehaviour {

    public string tagCheck;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == tagCheck)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);

            gameObject.SetActive(false);
        }
    }
}
