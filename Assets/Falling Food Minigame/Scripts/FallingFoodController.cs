using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Game Controller for the falling food game.
/// </summary>
public class FallingFoodController : MonoBehaviour, SpeedChanger {

  public SamController sam;

  //track prefab to spawn tracks from
  public Track regularTrackPrefab;

  //array of food prefabs
  public Food[] foodPrefabs;

  public Sprite finishLineSprite;

  //scoreboard visible on screen
  public PercentScores scoreTracker;

  public FoodScore finalScore;

  //all speed listeners current listening for speed changes
  List<SpeedListener> speedListeners;

  //speed of everything that scrolls
  private float scrollSpeed;

  //the percent speed that the player starts at
  private float startSpeedPercent = 25;

  //the duration of the race *at starting speed*, per second
  //i.e. faster speeds completes sooner, slower takes longer.
  [SerializeField]
  private float totalRaceDuration = 300;

  //current progress of the race, out of totalRaceDuration
  private float raceProgress = 0;

  //how much food, on average, will be on the screen at a given time
  private int numFoodOnScreen = 5;

  //the speed (in %) that will change each time food is collected
  private float speedChangePercent = 2;

  //min and max speed values - not in percent
  private float minSpeed = 0.1f, maxSpeed = 2;

  //depth of track from the camera - ensures it's visible
  private float trackOffsetFromCamera = 10;

  //array of two tracks that will be looping to simulate scroll
  private Track[] scrollingTracks;

  //indeces for the track array
  private const int LOWER_TRACK_INDEX = 0, UPPER_TRACK_INDEX = 1;

  private Timer gameTimer;


  // Use this for initialization
  void Start () {

    //Sets the initial scroll speed based on desired starting percent value
    scrollSpeed = ((startSpeedPercent / 100) * (maxSpeed - minSpeed)) + minSpeed;

    //initializes array of speed listeners
    speedListeners = new List<SpeedListener> ();

    //spawns two tracks that will be used throughout the game
    scrollingTracks = spawnTracks ();

    //spawns a healthy (or unhealthy) portion of food above camera
    for (int i = 0; i < numFoodOnScreen; i++) {

      //spawns food in space above camera
      spawnFood (Camera.main.orthographicSize * 2);

      //spawns food in 2x space above camera - ensures flow
      spawnFood (Camera.main.orthographicSize * 4);

    }

    //initializes the score tracker with correct speeds
    scoreTracker.Initialize (minSpeed, maxSpeed, scrollSpeed);

    //registers the score tracker as a speed listener
    registerSpeedListener (scoreTracker);

    gameTimer = new Timer();

  }

  void Update () {
   
    //updates race completion value
    updateCompletion ();
	
  }

  /// <summary>
  /// Spawns the two initial tracks that will loop for rest of minigame
  /// </summary>
  private Track[] spawnTracks () {

    Track[] scrollingTracks = new Track[2];

    //the location where the track will spawn- starting with camera position
    Vector3 trackSpawnPosition = Camera.main.transform.position;

    //changes depth to ensure track is visible
    trackSpawnPosition.z += trackOffsetFromCamera;

    //loops twice to spawn two tracks
    for (int trackNum = 0; trackNum < 2; trackNum++) {

      //creates and stores a new track
      scrollingTracks [trackNum] = (Track)GameObject.Instantiate (regularTrackPrefab, trackSpawnPosition, new Quaternion ());

      //registers the new track as a speed listener - will get speed updates
      registerSpeedListener (scrollingTracks [trackNum]);

      //initializes track values (only speed, in this case)
      scrollingTracks [trackNum].Initialize (scrollSpeed);

      //increases track spawn position for next track piece
      trackSpawnPosition.y += scrollingTracks [trackNum].getTrackHeight ();

    }

    return scrollingTracks;

  }

  /// <summary>
  /// Spawns food randomly in space directly above camera
  /// </summary>
  /// <param name="camOffset">How far above camera to spawn foodt.</param>
  private void spawnFood (float camOffset) {

    //height and width of camera - used to determine where to spawn food
    float camHeight = Camera.main.orthographicSize;
    float camWidth = camHeight * Camera.main.aspect;

    //gets a random location relative to camera boundaries
    Vector3 randomLoc = MyRandom.Location2D (Camera.main.transform.position, camWidth, camHeight);

    //sets y value of new location +offset above camera
    randomLoc.y += camOffset;

    //changes depth of new location to ensure spawned food will be visible and above track
    randomLoc.z = Camera.main.transform.position.z + trackOffsetFromCamera - 1;

    //gets a random food from the food prefabs
    Food randomFood = foodPrefabs [MyRandom.Index (foodPrefabs.Length)];

    //instantiates a random food
    Food newFood = (Food)GameObject.Instantiate (randomFood, randomLoc, new Quaternion ());

    //initializes food values
    newFood.Initialize (scrollSpeed, this);

    //registers the new food as a speed listener, will get scroll speed updates
    registerSpeedListener (newFood);

  }

  /// <summary>
  /// Updates the race completion value and displays on scoreboard
  /// </summary>
  private void updateCompletion () {

    //current rate of track completion as a numerical value, based on current speed
    float rateOfCompletion = (100 / startSpeedPercent) * ((scrollSpeed - minSpeed) / (maxSpeed - minSpeed));

    //increments track progress based on current rate of completion
    raceProgress += (rateOfCompletion) * (Time.deltaTime);

    //calculates completion percentage out of total race duration
    float completionPercentage = ((raceProgress / totalRaceDuration) * 100);

    if (completionPercentage >= 100) {

      completionPercentage = 100;
      scrollingTracks [UPPER_TRACK_INDEX].setFinish (finishLineSprite);
      finalScore.gameObject.SetActive(true);
      finalScore.Initialize(gameTimer, sam.getHealthyFood(), sam.getUnhealthyFood());
      scrollSpeed = 0;
      updateSpeedListener();

    }

    //displays the new completion percentage on the score tracker
    scoreTracker.displayRaceCompletion (completionPercentage);

  }

  /// <summary>
  /// Registers a speed listener.
  /// </summary>
  /// <param name="speedListenerObject">Speed listener object.</param>
  public void registerSpeedListener (SpeedListener speedListenerObject) {

    //registers the speedListenerObject as a speedListener to get updates
    speedListeners.Add (speedListenerObject);

  }

  /// <summary>
  /// Removes a speed listener.
  /// </summary>
  /// <param name="speedListenerObject">Speed listener object.</param>
  public void removeSpeedListener (SpeedListener speedListenerObject) {

    //removes the speedListenerObject from the speedListener list
    speedListeners.Remove (speedListenerObject);

  }

  /// <summary>
  /// Updates all speed listeners
  /// </summary>
  public void updateSpeedListener () {

    //updates all speedListeners with the new and correct speed
    foreach (SpeedListener speedListenerObject in speedListeners) {

      speedListenerObject.updateScrollSpeed (scrollSpeed);

    }
  }

  /// <summary>
  /// Updates the scroll speed.
  /// </summary>
  /// <param name="percentChange">Positive or negative speed change:
  /// -1 if negative and 1 if positive
  /// </param>
  public void updateScrollSpeed (int change) {

    //initially calculates current speed as a percent
    float newPercentSpeed = 100 * ((this.scrollSpeed - minSpeed) / (maxSpeed - minSpeed));

    //increments speed by the desired percent (either positive or negative
    newPercentSpeed += (change * speedChangePercent);

    //calculates new speed based on desired speed percent
    float newSpeed = (newPercentSpeed / 100) * (maxSpeed - minSpeed) + minSpeed;

    //if the new calculated speed is within max/min bounds
    if (newSpeed >= minSpeed && newSpeed <= maxSpeed) {

      //update scroll speed in this class
      this.scrollSpeed = newSpeed;

      //notify all speed listeners of speed change
      updateSpeedListener ();
    }

    //if speed change is too high
    else if (newSpeed >= maxSpeed) {

      //display a speed percent of 100 by default, exceeded max
      scoreTracker.displaySpeedPercent (100);

    }

    //if speed change is too low
    else if (newSpeed <= minSpeed) {

      //display a speed percent of 1 by default, exceeded min
      scoreTracker.displaySpeedPercent (1);

    }
  }

  /// <summary>
  /// Removes food from the game after it's been used or scrolled past
  /// </summary>
  /// <param name="food">Food to remove.</param>
  public void removeFood (Food food) {

    //removes this food from the list of speedListeners
    speedListeners.Remove (food);

    //destroys the food gameObject
    GameObject.Destroy (food.gameObject);

    //spawns a new piece of food
    spawnFood (Camera.main.orthographicSize * 2);

  }
}
