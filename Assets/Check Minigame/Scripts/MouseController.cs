using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
 
  private FloatingWord storedWord;
  private CheckSlots storedSlot;
  private Vector3 mouseOffset;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
  
    //checks left mouse button / tap
    if (Input.GetMouseButton(0)) {

      //if there's a currently stored word that isn't locked, update it to the mouse position
      if (storedWord && !storedWord.getLocked()) {

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
        storedWord.transform.position = newPosition;

      }

    }

    //Checks initial mouse press
    if (Input.GetMouseButtonDown(0)) {

        //checks if the user is pressing on the draggable object
        RaycastHit2D hit = Physics2D.Raycast(
         Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

         //if user is clicking on a floating word
         if (hit && hit.collider.GetComponent<FloatingWord>()) {

          //set the floating word to grabbed
          storedWord = hit.collider.GetComponent<FloatingWord>();
          storedWord.setGrabbed(true);

          //calculates mouse offset from last frame
          mouseOffset = storedWord.transform.position - Camera.main.ScreenToWorldPoint(
                       new Vector3(Input.mousePosition.x,
                                   Input.mousePosition.y,
                                   Input.mousePosition.z));


      }
    }


    //when the mouse button is released
    if (Input.GetMouseButtonUp(0)) {

      //if there's a stored word...get rid of it.
      if (storedWord) {

        storedWord.setGrabbed(false);
        storedWord = null;

      }
    }
  }
}
