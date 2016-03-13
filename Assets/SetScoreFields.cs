using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetScoreFields : MonoBehaviour {

  public Text scoreText;

  private int minutes;
  private int seconds;

	// Use this for initialization
	void OnEnable () {

    convertElapsedTime();

    scoreText.text = "Time: " + minutes + " minutes and " + seconds + " seconds" + "\n\n" +
                     "Check Fields Completed: " + Controller.blanksFilled + "\n\n" +
                     "Whole Checks Completed: " + Controller.checksCompleted + "\n\n" +
                     "Total Score: " + (Controller.blanksFilled + 5*Controller.checksCompleted);


    GlobalScore.score += Controller.blanksFilled + (5*Controller.checksCompleted);
                     
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


  void convertElapsedTime() {

    minutes = 0;
    seconds = 0;
    int totalTime = (int)Controller.elapsedTime;



    while (totalTime > 60) {

      minutes++;
      totalTime-=60;

    }

    seconds = totalTime;

  }
}
