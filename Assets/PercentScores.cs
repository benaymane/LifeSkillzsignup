using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PercentScores : MonoBehaviour {

  public Text raceCompletedText;
  public Text currentSpeedText;

  private float currentRaceCompletion;
  private float currentSpeed;

	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {

    updateRaceCompletion(Tile.raceCompletedPercent);
    raceCompletedText.text = "Race Completed: " + (int)currentRaceCompletion + "%";
    currentSpeedText.text = "Current Speed: " + (int)currentSpeed + "%";

	}

  public void updateRaceCompletion(float percent) {


    currentRaceCompletion = percent;


  }

  public void updateSpeed(float percent) {

    currentSpeed = percent;

  }
}
