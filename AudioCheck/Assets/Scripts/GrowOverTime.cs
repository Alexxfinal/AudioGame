using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOverTime : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime) * 2;	
	}
}
