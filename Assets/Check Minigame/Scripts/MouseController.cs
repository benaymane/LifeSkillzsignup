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
  
    if (Input.GetMouseButton(0)) {

      if (storedWord) {

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
        storedWord.transform.position = newPosition;

      }

      else {

        //checks if the user is pressing on the draggable object
        RaycastHit2D hit = Physics2D.Raycast(
         Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

         if (hit && hit.collider.GetComponent<FloatingWord>()) {

          storedWord = hit.collider.GetComponent<FloatingWord>();
          storedWord.setGrabbed(true);

          mouseOffset = storedWord.transform.position - Camera.main.ScreenToWorldPoint(
                       new Vector3(Input.mousePosition.x,
                                   Input.mousePosition.y,
                                   Input.mousePosition.z));

      

         }
      }
    }


    if (Input.GetMouseButtonUp(0)) {

      if (storedWord) {

        storedWord.setGrabbed(false);
        storedWord = null;

      }
    }
  }
}
