using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongDifficulty : MonoBehaviour {

    public List<float> timeStamp = new List<float>();
    public List<float> difficulty = new List<float>();

    float currentTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
	}
}
