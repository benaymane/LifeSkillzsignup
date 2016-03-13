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

	private bool dialogueControl = true;
	private int count = 0;

	// Use this for initialization
	void Start () {
		speechBubble.SetActive (true);
		introDialogue.SetActive (true);
		gameDialogue.SetActive (false);
		checkButton.GetComponent<Button> ().interactable = false;
		schoolButton.GetComponent<Button> ().interactable = false;
		bathroomButton.GetComponent<Button> ().interactable = false;
	}

	// Update is called once per frame
	void Update () {
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
	}
}

