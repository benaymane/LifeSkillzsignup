using UnityEngine;
using System.Collections;

public class FinishButton : MonoBehaviour {

  private float elapsedTime;
  private float lastRecordedTime;
  public static int teethCleaned = 0;

  public GameObject scoreScreen;

	// Use this for initialization
	void Start () {

    elapsedTime = 0;
    FinishButton.teethCleaned = 0;
    lastRecordedTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

    if (Time.time - lastRecordedTime >= 1) {

      elapsedTime++;
      lastRecordedTime = Time.time;

    }
	}

  public void loadScoreScreen() {

    scoreScreen.SetActive(true);
    scoreScreen.GetComponentsInChildren<TeethScore>()[0].setElapsedTime(elapsedTime);

  }
}
