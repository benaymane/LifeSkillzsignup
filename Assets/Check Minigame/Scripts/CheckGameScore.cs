using UnityEngine;
using System.Collections;
using System;

public class CheckGameScore : MonoBehaviour {

    public static CheckGameScore scoreScript;

	// Use this for initialization
	void Start () {

	  scoreScript = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore() {

      long currNum = Convert.ToInt64(this.gameObject.GetComponent<TextMesh>().text);
      currNum+=20;
      this.gameObject.GetComponent<TextMesh>().text = currNum.ToString();

	}

	public void decreaseScore() {

		long currNum = Convert.ToInt64(this.gameObject.GetComponent<TextMesh>().text);
		currNum-=20;
		this.gameObject.GetComponent<TextMesh>().text = currNum.ToString();

	}
}
