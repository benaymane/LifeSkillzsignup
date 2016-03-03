using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{

    public int thisPieceIndex;
    private bool draggable = true;
    private bool clicked = false;
    public static Draggable dragging = null;

    private Vector3 mouseOffset;
    private Vector3 currPos;

    // Use this for initialization
    void Start()
    {
        currPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //when the button is first pressed down
        if (Input.GetMouseButtonDown(0))
        {

            //set the mouse offset from the center of the game object
            mouseOffset = currPos - Camera.main.ScreenToWorldPoint(
              new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          Input.mousePosition.z));


        }

        //while the mouse button is being held down
        if (Input.GetMouseButton(0))
        {

            //checks if the user is pressing on the draggable object
            RaycastHit2D hit = Physics2D.Raycast(
              Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);


            //if object is being pressed
            if (clicked || (hit && hit.collider.GetComponent<Draggable>() == this))
            {

                //if the object can currently be dragged
                if (draggable && (Draggable.dragging == null || Draggable.dragging == this))
                {

                    clicked = true;

                    Draggable.dragging = this;

                    //calculates location where object should be dragged
                    Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;

                    //sets current object's position
                    this.transform.position = newPosition;

                    //updates current object position
                    currPos = this.transform.position;

                }
            }
        }

        else {
            clicked = false;

            mouseOffset = currPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                               Input.mousePosition.y,
                                                                               Input.mousePosition.z));

            Draggable.dragging = null;

        }
    }

    /*
	 * If the dragged object is within a check slot
	 */
    void OnTriggerStay2D(Collider2D slot)
    {

        //variable for the slot that the object was dragged to
        CheckSlots draggedSlot;

        //sets the correct slot
        draggedSlot = slot.gameObject.GetComponent<CheckSlots>();

        //if the object was dragged to a slot
        if (draggedSlot)
        {

            //if the mouse button is not still being pressed
            if (!Input.GetMouseButton(0))
            {

                //if the index of the slot matches the index of the piece
                if (draggedSlot.getSearchString() == GetComponent<TextMesh>().text && draggable)
                {

                    //snap the check piece into place
                    Snap(draggedSlot.gameObject.transform.position);

                }
            }
        }
    }

    /*
	 * Snaps an object to a location
	 */
    void Snap(Vector2 location)
    {

        //sets position
        this.transform.position = location;

        Score.scoreScript.addScore();

        //makes object impossible to drag anymore.
        draggable = false;

    }
}
