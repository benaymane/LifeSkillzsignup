using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Food object that Sam can grab in the same
/// </summary>
public abstract class Food : MonoBehaviour, SpeedListener {

  //audio that should be played when this food is grabbed
  public AudioClip foodAudio;

  //scroll speed of this food
  private float scrollSpeed;

  //initial start position of the food
  private Vector3 startPosition;

  //timer that keeps track of how long food has existed
  private Timer scrollTimer;

  //reference to the game controller
  FallingFoodController controller;

  //float to keep track of next position for scroll
  private float nextPosition;

  //lower boundary of the camera, to check if food is on screen
  private float camLowerBound;

  // Use this for initialization
  void Start() {

    //stores initial position of food, to be used with scroll offset
    startPosition = transform.position;

    //stores the lower bound of the camera, to check if food is on screen
    camLowerBound = Camera.main.transform.position.y - Camera.main.orthographicSize;

  }
	
  // Update is called once per frame
  void Update() {

    //scrolls the food
    scroll();

    //if the food is off the screen, remove it
    if (this.transform.position.y < camLowerBound) {

      this.remove();

    }
  }

  /// <summary>
  /// Initialize this piece of food
  /// </summary>
  /// <param name="speed">Speed of food.</param>
  /// <param name="controller">Controller that made this.</param>
  public void Initialize(float speed, FallingFoodController controller) {

    //initializes values for the food before it begins scrolling
    this.scrollSpeed = speed;
    this.controller = controller;
    scrollTimer = new Timer();

  }

  /// <summary>
  /// Scrolls the food object downward
  /// </summary>
  public void scroll() {

    //updates the next position of the food at an offset from startPosition
    nextPosition = scrollTimer.getElapsedTime() * scrollSpeed;

    //changes position downward
    this.transform.position = startPosition + (Vector3.down * nextPosition);

  }

  /// <summary>
  /// Updates the scroll speed.
  /// </summary>
  /// <param name="speed"> New speed.</param>
  public void updateScrollSpeed(float speed) {

    //calculates the value that startTimer should be in order to keep same position
    //Explanation of Algorithm:
    //       if we originally reach position 5 in 10 seconds, then a 2x increase in speed
    //       would allow us to reach position 5 in 5 seconds. So, we have to update the
    //       timer to accurately reflect how much time should've passed at the new speed
    //       to reach the current position of the food, otherwise the food will jump
    //       because the timer will still be the same, and it knows that in 10 seconds with
    //       a 2x speed the position should be 10, not 5. Therefore we'd see the food move
    //       from position 5 to 10 instantly, which certainly doesn't flow. So instead, we set
    //       the timer to a new value and keep the position constant, and use the new speed
    //       in the equation to ensure that the food doesn't move in the transition.
    if (speed > 0)
      scrollTimer.set(nextPosition / speed);

    //updates speed to new speed
    this.scrollSpeed = speed;

  }

  /// <summary>
  /// Remove this food.
  /// </summary>
  public void remove() {

    //calls the controller to remove this piece of food
    controller.removeFood(this);

  }

  /// <summary>
  /// Plays the audio attached to this food object.
  /// </summary>
  public AudioClip getAudio() {

    //returns the audio attached to this piece of food
    return foodAudio;

  }

  /// <summary>
  /// Checks if this food is healthy
  /// </summary>
  /// <returns><c>true</c>, If food is healthy, <c>false</c> otherwise.</returns>
  public abstract bool isHealthy();

}