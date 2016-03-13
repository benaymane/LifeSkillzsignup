using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeethScore : MonoBehaviour {

  private float numTeeth = 19;

  private float elapsedTime;

  private int teethCleaned;
  private int finishBonus = 0;

  public Text textToUpdate;
  private int minutes = 0;
  private int seconds;

	// Use this for initialization
	void Start () {

    teethCleaned = FinishButton.teethCleaned;
    convertElapsedTime();
    if (FinishButton.teethCleaned == numTeeth) finishBonus = 10;

    textToUpdate.text = "Total Time: " + minutes + " minutes and " + seconds + " seconds\n\n" +
                        "Teeth Cleaned: " + teethCleaned + "\n\n" +
                        "Finish Bonus: " + finishBonus + "\n\n" + 
                        "Total Score: " + (teethCleaned + finishBonus);

    GlobalScore.addScore(teethCleaned + finishBonus);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void setElapsedTime(float time) {

    this.elapsedTime = time;
  

  }

  void convertElapsedTime() {

    minutes = 0;
    seconds = 0;
    int totalTime = (int)elapsedTime;

    while (totalTime > 60) {

      minutes++;
      totalTime-=60;

    }

    seconds = totalTime;

  }
}
