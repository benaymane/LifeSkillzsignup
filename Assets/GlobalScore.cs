using UnityEngine;
using System.Collections;

public class GlobalScore : MonoBehaviour {

  public static int score = 0;

	// Use this for initialization
	void Awake () {

    GlobalScore.score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

  public static void addScore(int num) {



    GlobalScore.score+=num;

  }

  public static int getScore() {

    return GlobalScore.score;

  }
}
