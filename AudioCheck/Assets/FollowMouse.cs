using UnityEngine;

public class FollowMouse : MonoBehaviour {

	void Update ()
    {
        //transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;

        transform.position = position;
    }
}
