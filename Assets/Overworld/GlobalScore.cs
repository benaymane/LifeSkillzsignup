using UnityEngine;
using System.Collections;

public class GlobalScore : MonoBehaviour {
    

	// Use this for initialization
	void Awake () {
        
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

  public static void addScore(int num) {


        User.updateScore(num);
    //GlobalScore.score+=num;

  }

  public static int getScore() {

    return User.score;

  }
}
