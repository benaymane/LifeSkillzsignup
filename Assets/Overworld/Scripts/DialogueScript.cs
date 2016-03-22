using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour {

  public GameObject introDialogue;
  public GameObject gameDialogue;
  public GameObject startButton;
  public GameObject nextButton;
 
  // Use this for initialization
  void Start() {
    
    introDialogue.SetActive(true);
    gameDialogue.SetActive(false);
    startButton.SetActive(false);
    nextButton.SetActive(true);

  }
	
  // Update is called once per frame
  void Update() {
    /*
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
		*/
  }

  public void Next() {
    
    introDialogue.SetActive(false);
    gameDialogue.SetActive(true);
    startButton.SetActive(true);
    nextButton.SetActive(false);

  }
}
