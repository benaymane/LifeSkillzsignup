using UnityEngine;
using System.Collections;

public class FloatingWord : MonoBehaviour {

  private float floatDuration;
  private Vector3 endLocation;
  private CheckSlots lockedSlot;

  private bool grabbed = false;
  private bool locked = false;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {


	}

  public void setFloatDuration(float duration) {

    this.floatDuration = duration;


  }

  public void setEndLocation(Vector3 endLocation) {

    this.endLocation = endLocation;

  }

  public void setGrabbed(bool grabbed) {

    if (grabbed == false) {

      if (lockedSlot) {

        Snap(lockedSlot.transform.position);

      }

      else {

        GameObject.Destroy(this.gameObject);
        return;

      }
    }

    this.grabbed = grabbed;
  }

  public void beginFloat() {


    StartCoroutine(floatWord());


  }

  public void setLocked(bool locked) {

    this.locked = locked;

  }

  void OnTriggerStay2D(Collider2D other) {

    Debug.Log("ON SLOTTTT");

    if (other.GetComponent<CheckSlots>()) {
      if (other.GetComponent<CheckSlots>().getSearchString() == GetComponent<TextMesh>().text) {

        Debug.Log("YAY");
        lockedSlot = other.GetComponent<CheckSlots>();

      }
    }
  }

  /*
   * Snaps an object to a location
   */
  void Snap(Vector2 location) {

    //sets position
    this.transform.position = location;

    Score.scoreScript.addScore();

    locked = true;

  }

  IEnumerator floatWord() {

    float i = 0;
    Vector3 startLocation = this.transform.position;

    while (this.transform.position.x > endLocation.x) {

      if (!grabbed && !locked) {

        this.transform.localPosition = Vector3.Lerp(startLocation, endLocation, i/floatDuration);
        i+=Time.deltaTime;

      }

      yield return null;

    }

    GameObject.Destroy(this.gameObject);

  }
}
