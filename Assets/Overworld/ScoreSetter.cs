﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Sxcore: " + GlobalScore.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
