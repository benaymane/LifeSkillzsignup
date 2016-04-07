using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//
public class SetFoodFields : MonoBehaviour {

  public Text scoreText;

  private int healthyFood;
  private int unhealthyFood;

  // Update is called once per frame
  void Update() {
  
  }

  void convertElapsedTime() {

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
    if (totalScore < 0)
      totalScore = 0;

    GlobalScore.score += totalScore;





  }
}
