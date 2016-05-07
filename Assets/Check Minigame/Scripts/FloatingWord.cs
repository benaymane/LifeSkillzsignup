using UnityEngine;
using System.Collections;

public class FloatingWord : MonoBehaviour {

  public static ArrayList lockedWordObjects;
  public static ArrayList lockedWords;
  public static int fieldsFilled;

  public AudioSource successClip;
  public AudioSource failClip;

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
       if (!(FloatingWord.lockedWords).Contains(lockedSlot.getSearchString())) {

        Snap(lockedSlot.transform.position);

        }
      }

      else {
        Controller.failClip.Play();
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

  public bool getLocked() {

    return locked;

  }

  /// <summary>
  /// Checks if the floating word has been dragged into a check field
  /// </summary>
  /// <param name="other"></param>
  void OnTriggerStay2D(Collider2D other) {

    if (other.GetComponent<CheckSlots>()) {
      if (other.GetComponent<CheckSlots>().getSearchString() == GetComponent<TextMesh>().text) {

        lockedSlot = other.GetComponent<CheckSlots>();

      }
    } 
  }


  /// <summary>
  /// Snaps a floating word into the correct check field
  /// </summary>
  /// <param name="location"></param>
  void Snap(Vector2 location) {

    //sets position
    this.transform.position = location;
    FloatingWord.lockedWordObjects.Add(this.gameObject);
    lockedWords.Add(GetComponent<TextMesh>().text);

    locked = true;
    FloatingWord.fieldsFilled++;
    Controller.blanksFilled++;
    successClip.Play();

  }

  /// <summary>
  /// Moves the word across the screen
  /// </summary>
  /// <returns></returns>
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
