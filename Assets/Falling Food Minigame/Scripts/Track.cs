using UnityEngine;
using System.Collections;

/// <summary>
/// Scrollable track tile for the food game
/// </summary>
public class Track : MonoBehaviour, SpeedListener {

  //speed that the tile is scrolling
  private float scrollSpeed;

  //start position, for calculating scroll position
  private Vector3 startPosition;

  //next position track should move to, for scrolling
  private float nextPosition;

  private float lastPosition;
 
  //timer to keep track of where track should be at a given time
  Timer trackTimer;

  Sprite finishLineSprite;

  private bool raceComplete, scrolling = true;

  // Use this for initialization
  void Start() {

    //sets the start position
    startPosition = transform.position;
    
  }
	
  // Called once per frame
  void Update() {

    //scrolls the track piece
    scroll();
  
  }

  //initializes some values passed by the controller
  public void Initialize(float speed) {

    this.scrollSpeed = speed;
    trackTimer = new Timer();


  }

  /// <summary>
  /// Updates the scroll speed.
  /// </summary>
  /// <param name="speed">Speed.</param>
  public void updateScrollSpeed(float speed) {
    
    //calculates the value that trackTimer should be in order to keep same position
    //Explanation of Algorithm:
    //       if we originally reach position 5 in 10 seconds, then a 2x increase in speed
    //       would allow us to reach position 5 in 5 seconds. So, we have to update the
    //       timer to accurately reflect how much time should've passed at the new speed
    //       to reach the current position of the track, otherwise the track will jump
    //       because the timer will still be the same, and it knows that in 10 seconds with
    //       a 2x speed the position should be 10, not 5. Therefore we'd see the track move
    //       from position 5 to 10 instantly, which certainly doesn't flow. So instead, we set
    //       the timer to a new value and keep the position constant, and use the new speed
    //       in the equation to ensure that the track doesn't move in the transition.
    if (speed > 0)
      trackTimer.set(nextPosition / speed);

    //updates the speed
    this.scrollSpeed = speed;
  }

  /// <summary>
  /// Scrolls the track downward
  /// </summary>
  public void scroll() {

    float scrollProgress = trackTimer.getElapsedTime() * scrollSpeed;

    //scrolls the tile until it's moved it's entire height, at which point it starts over from top
    nextPosition = Mathf.Repeat(scrollProgress, getTrackHeight());

    /* 
     * TODO: Implement finish line
    if (!scrolling && (nextPosition < lastPosition)) {

      return;

    }
    */

    //float newPosition = trackTimer.getElapsedTime() * speed;
    transform.position = startPosition + (Vector3.down * nextPosition);

    /*
     * TODO: Implement finish line
    if (raceComplete && scrolling && (nextPosition < lastPosition)) {

      convertToFinishLine();
      stopScrolling();

    }
    */
  
    lastPosition = nextPosition;

  }

  /// <summary>
  /// Gets the size of the track vertical.
  /// </summary>
  /// <returns>The vertical size.</returns>
  public float getTrackHeight() {

    //gets the vertical size according to the sprite renderer bounds
    return this.GetComponent<SpriteRenderer>().bounds.size.y;

  }

  public void setFinish(Sprite finishSprite) {

    this.finishLineSprite = finishSprite;
    raceComplete = true;

  }

  private void convertToFinishLine() {

    this.GetComponent<SpriteRenderer>().sprite = finishLineSprite;

  }

  private void stopScrolling() {
  
    scrolling = false;
  
  }
}
