using UnityEngine;

public class ObjectDisable : MonoBehaviour
{

    Rigidbody2D myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    

    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);

        if (myBody != null)
            //Reset velocity after deactivating to remove unwanted values
            myBody.velocity = new Vector3(0f, 0f, 0f); 

        else if (myBody == null)
            Debug.Log("No Rigidbody2D found. Is this right?");

    }

    void OnDisable()
    {
        CancelInvoke();
    }
}