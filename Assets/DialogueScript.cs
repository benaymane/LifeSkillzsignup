using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour {

	public GameObject introDialogue;
	public GameObject gameDialogue;
	public GameObject startButton;

	private bool dialogueControl = true;

	// Use this for initialization
	void Start () {
		introDialogue.SetActive (true);
		gameDialogue.SetActive (false);
		startButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform != RuntimePlatform.Android ) {
			if (Input.GetMouseButtonDown(0)) {
				if (dialogueControl) {
					introDialogue.SetActive (false);
					gameDialogue.SetActive (true);
					startButton.SetActive (true);
					dialogueControl = false;
				}
			}
		} else {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				introDialogue.SetActive (false);
				gameDialogue.SetActive (true);
				startButton.SetActive (true);
			}
		}
	}
}
