using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

  private float lastRecordedTime;
  private float timer = 10;

	// Use this for initialization
	void Start () {

    updateText();
    lastRecordedTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

    if (Time.time - lastRecordedTime > 1) {

      lastRecordedTime = Time.time;
      timer--;
      updateText();

    }
	}

  void updateText() {


    if (timer > 0) {
      GetComponent<Text>().text = "Begin Race In " + timer + " seconds";
    }

    else {
      this.transform.parent.GetComponent<Button>().interactable = true;
      GetComponent<Text>().text = "Begin Race";

    }
  }
}
