using UnityEngine;
using System.Collections;
using System;

public class Score : MonoBehaviour {

    public static Score scoreScript;

	// Use this for initialization
	void Start () {

	  scoreScript = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore() {

      long currNum = Convert.ToInt64(this.gameObject.GetComponent<TextMesh>().text);
      currNum++;
      this.gameObject.GetComponent<TextMesh>().text = currNum.ToString();

	}
}
