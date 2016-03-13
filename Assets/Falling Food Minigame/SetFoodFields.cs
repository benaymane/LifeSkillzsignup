using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetFoodFields : MonoBehaviour {

  public Text scoreText;

  private int minutes;
  private int seconds;
  private int healthyFood;
  private int unhealthyFood;

  // Update is called once per frame
  void Update () {
  
  }


  void convertElapsedTime() {

    minutes = 0;
    seconds = 0;
    int totalTime = (int)ScrollTrack.elapsedTime;



    while (totalTime > 60) {

      minutes++;
      totalTime-=60;

    }

    seconds = totalTime;

  }

  public void setHealthyFoodValue(int val) {

    healthyFood = val;

  }

  public void setUnhealthyFoodValue(int val) {

    unhealthyFood = val;

  }

  public void updateScore() {

    convertElapsedTime();

    int totalScore = (healthyFood - unhealthyFood);
    if (totalScore < 0) totalScore = 0;

    scoreText.text = "Time: " + minutes + " minutes and " + seconds + " seconds" + "\n\n" +
                     "Healthy Food Eaten: " + healthyFood + "\n\n" +
                     "Unhealthy Food Eaten: " + unhealthyFood + "\n\n" +
                     "Total Score: " + totalScore; 


    GlobalScore.score += totalScore;


  }
}
