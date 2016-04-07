using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FoodScore : MonoBehaviour {

  public Text scoreText;

  public void Initialize(Timer gameTimer, int healthyFood, int unhealthyFood) {

    scoreText.text = "Time: " + gameTimer.toString() + "\n" +
                     "Healthy Food Grabbed: " + healthyFood + "\n" +
                     "Unhealthy Food Grabbed: " + unhealthyFood + "\n" +
                     "Final Score: " + (healthyFood - unhealthyFood);


    GlobalScore.addScore(healthyFood - unhealthyFood);

  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void returnToCity() {

    SceneManager.LoadScene(0);

  }
}
