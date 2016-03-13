using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverviewStart : MonoBehaviour {

	public GameObject speechBubble;
	public GameObject introDialogue;
	public GameObject gameDialogue;
	public GameObject checkButton;
	public GameObject schoolButton;
	public GameObject bathroomButton;
	public GameObject nextButton;

	public static bool dialogueControl = true;

	// Use this for initialization
	void Start () {
		if (OverviewStart.dialogueControl) {
			speechBubble.SetActive (true);
			introDialogue.SetActive (true);
			gameDialogue.SetActive (false);
			nextButton.SetActive (true);
			checkButton.GetComponent<Button> ().interactable = false;
			schoolButton.GetComponent<Button> ().interactable = false;
			bathroomButton.GetComponent<Button> ().interactable = false;
		} else {
			speechBubble.SetActive (false);
			introDialogue.SetActive (false);
			gameDialogue.SetActive (false);
			nextButton.SetActive (false);
			checkButton.GetComponent<Button> ().interactable = true;
			schoolButton.GetComponent<Button> ().interactable = true;
			bathroomButton.GetComponent<Button> ().interactable = true;
		}
	}

	// Update is called once per frame
	void Update () {
		/*
		if (Application.platform != RuntimePlatform.Android ) {
			if (Input.GetMouseButtonDown(0)) {
				count++;
				if (dialogueControl) {
					introDialogue.SetActive (false);
					gameDialogue.SetActive (true);
				} 
				if (count == 2) {
					speechBubble.SetActive (false);
					gameDialogue.SetActive (false);
					checkButton.GetComponent<Button> ().interactable = true;
					schoolButton.GetComponent<Button> ().interactable = true;
					bathroomButton.GetComponent<Button> ().interactable = true;
					dialogueControl = false;
				}
			}
		} else {
			if (Input.touchCount >= 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				count++;
				if (dialogueControl) {
					introDialogue.SetActive (false);
					gameDialogue.SetActive (true);
				} 
				if (count == 2) {
					speechBubble.SetActive (false);
					gameDialogue.SetActive (false);
					checkButton.GetComponent<Button> ().interactable = true;
					schoolButton.GetComponent<Button> ().interactable = true;
					bathroomButton.GetComponent<Button> ().interactable = true;
					dialogueControl = false;
				}
			}
		}
		*/
	}

	public void Next() {
		if (OverviewStart.dialogueControl) {
			introDialogue.SetActive (false);
			gameDialogue.SetActive (true);
			checkButton.GetComponent<Button> ().interactable = true;
			schoolButton.GetComponent<Button> ().interactable = true;
			bathroomButton.GetComponent<Button> ().interactable = true;
			OverviewStart.dialogueControl = false;
			nextButton.SetActive (false);
		}
	}



}

